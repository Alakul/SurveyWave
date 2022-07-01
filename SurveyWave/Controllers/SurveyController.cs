using ASP.NETcoreSurveyApp.Data;
using ASP.NETcoreSurveyApp.Models;
using Biblioteczka.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyWave.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ASP.NETcoreSurveyApp.Controllers
{
    public class SurveyController : Controller
    {
        AppDbContext db;
        public SurveyController(AppDbContext context)
        {
            db = context;
        }

        // GET: SurveController
        public ActionResult Index(string searchString, string sortOrder, string formValue, string selectStatus)
        {
            List<Survey> surveys = db.Survey.ToList();
            HttpContextAccessor httpContextAccessor = new HttpContextAccessor();
            var tuple = AppMethods.Search(httpContextAccessor, surveys, "SearchStringSurvey", formValue, searchString);
            surveys = tuple.Item1;
            ViewBag.SearchString = tuple.Item2;

            surveys = AppMethods.Sort(httpContextAccessor, surveys, "SortOrderSurvey", sortOrder);
            ViewData["Selected"] = AppMethods.SetViewData(httpContextAccessor, sortOrder, "SortOrderSurvey", "DateDesc");
            ViewBag.Values = AppData.surveySort;

            surveys = AppMethods.SelectStatus(httpContextAccessor, surveys, "StatusSurvey", selectStatus);
            ViewData["SelectedStatus"] = AppMethods.SetViewData(httpContextAccessor, selectStatus, "StatusSurvey", "A");
            ViewBag.Status = AppData.status;

            return View(surveys);
        }

        // GET: SurveController/Details/5
        public ActionResult Details(int id)
        {  
            SurveyViewModel surveyViewModel = new SurveyViewModel();
            surveyViewModel.Survey = db.Survey.Where(x => x.Id == id).Single();
            surveyViewModel.Questions = db.Question.Where(x => x.SurveyId == id).ToList();
            surveyViewModel.Answers = db.Answer.ToList();

            return View(surveyViewModel);
        }

        // GET: SurveController/Create
        public ActionResult Create()
        {
            SurveyViewModel surveyViewModel = new SurveyViewModel();
            surveyViewModel.Questions = new List<Question>() { new Question() };
            surveyViewModel.Answers = new List<Answer>() { new Answer() };
            return View(surveyViewModel);
        }

        // POST: SurveController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, SurveyViewModel model)
        {
            if (ModelState.IsValid)
            {
                Survey survey = new Survey
                {
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    Title = model.Survey.Title,
                    Description = model.Survey.Description,
                    Date = DateTime.Now,
                    StartDate = model.Survey.StartDate,
                    EndDate = model.Survey.EndDate,
                    Status = model.Survey.Status,
                };

                db.Survey.Add(survey);
                db.SaveChanges();

                for (int i=0; i<model.Questions.Count; i++)
                {
                    Question question = new Question
                    {
                        SurveyId = survey.Id,
                        Number = i+1,
                        Text = model.Questions[i].Text,
                        Type = model.Questions[i].Type,
                    };
                    db.Question.Add(question);
                    db.SaveChanges();

                    for (int j=0; j < model.Questions[i].Answers.Count; j++)
                    {
                        Answer answer = new Answer
                        {
                            QuestionId = question.Id,
                            Number = i+1,
                            Text = model.Questions[i].Answers[j].Text,
                        };
                        db.Answer.Add(answer);
                        db.SaveChanges();
                    }
                }

                TempData["Alert"] = "Success";
                return RedirectToAction(nameof(Create));
            }
            else
            {
                TempData["Alert"] = "Danger";
                SurveyViewModel surveyViewModel = new SurveyViewModel();
                surveyViewModel.Questions = new List<Question>() { new Question() };
                surveyViewModel.Answers = new List<Answer>() { new Answer() };
                return View(nameof(Create), surveyViewModel );
            }
        }
        public IActionResult AddQuestion(int index)
        {
            return PartialView("Templates/_Question", new Question() { Index = index });
        }
        public IActionResult AddAnswer(int questionIndex, int index, string type)
        {
            return PartialView("Templates/_Answer", new Answer() { QuestionIndex = questionIndex, Index = index, QuestionType = type });
        }

        // GET: SurveController/Edit/5
        public ActionResult Edit(int id)
        {
            SurveyViewModel surveyViewModel = new SurveyViewModel();
            surveyViewModel.Survey = db.Survey.Where(x => x.Id == id).Single();
            surveyViewModel.Questions = db.Question.Where(x => x.SurveyId == id).ToList();
            surveyViewModel.Answers = db.Answer.ToList();
            return View(surveyViewModel);
        }

        // POST: SurveController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SurveController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SurveController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                db.Remove(db.Survey.Where(x => x.Id == id).Single());
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        public ActionResult ShowResults(int id)
        {
            ResponseViewModel responseViewModel = new ResponseViewModel();

            List<ResponseViewModel> responses = db.Survey
                .Join(db.Question, a => a.Id, b => b.SurveyId, (a, b) => new { survey = a, question = b })
                .Join(db.Answer, joined => joined.question.Id, b => b.QuestionId, (joined, b) => new { joined, answer = b })
                .Join(db.Response, joinedTwice => joinedTwice.answer.Id, response => response.AnswerId,
                (joinedTwice, response) => new ResponseViewModel
                {
                    Survey = joinedTwice.joined.survey,
                    Response = response,
                })
                .Where(x=>x.Survey.Id == id).ToList();

            responseViewModel.Responses = responses;
            responseViewModel.Survey = db.Survey.Where(x => x.Id == id).Single();
            responseViewModel.Questions = db.Question.Where(x => x.SurveyId == id).ToList();
            responseViewModel.Answers = db.Answer.ToList();
            return View(responseViewModel);
        }

        public IActionResult SelectStatus(string selectStatus)
        {
            List<Survey> surveys = db.Survey.ToList();
            if (selectStatus == "C" || selectStatus == "O"){
                surveys = db.Survey.Where(x => x.Status == selectStatus).ToList();
            }
            ViewData["SelectedStatus"] = selectStatus;

            Dictionary<string, string> status = new Dictionary<string, string> {
                {"A", "Wszystkie"},
                {"O", "Otwarte"},
                {"C", "Zamknięte"}
            };
            ViewBag.Status = status;

            return View(nameof(Index), surveys);
        }
    }
}
