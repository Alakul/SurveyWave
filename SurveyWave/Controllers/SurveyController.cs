using SurveyWave.Data;
using SurveyWave.Models;
using Biblioteczka.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using X.PagedList;

namespace SurveyWave.Controllers
{
    public class SurveyController : Controller
    {
        AppDbContext db;
        public SurveyController(AppDbContext context)
        {
            db = context;
        }

        // GET: SurveController
        public ActionResult Index(int? page, string searchString, string sortOrder, string formValue, string selectStatus)
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

            int pageSize = 20;
            int pageNumber = (page ?? 1);
            IPagedList<Survey> pageSurvey = surveys.ToPagedList(pageNumber, pageSize);

            return View(pageSurvey);
        }

        // GET: SurveController/Details/5
        public ActionResult Details(int id)
        {  
            SurveyViewModel surveyViewModel = new SurveyViewModel();
            surveyViewModel.Survey = db.Survey.Where(x => x.Id == id).Single();
            surveyViewModel.Questions = db.Question.Where(x => x.SurveyId == id).ToList();
            surveyViewModel.Answers = db.Answer.ToList();
            surveyViewModel.User = db.Users.Where(x => x.Id == surveyViewModel.Survey.UserId).Single();

            string user = User.FindFirstValue(ClaimTypes.NameIdentifier);

            List<ResponseInfo> responseInfo = db.ResponseInfo.Where(x=>x.SurveyId==id && x.UserId == user).ToList();
            if (responseInfo.Count != 0){
                ViewBag.Filled = true;
            }

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
        public ActionResult Edit(int id, IFormCollection collection, SurveyViewModel model)
        {
            if (ModelState.IsValid)
            {
                Survey survey = db.Survey.Where(x => x.Id == id).Single();
                survey.Title = model.Survey.Title;
                survey.Description = model.Survey.Description;
                survey.Status = model.Survey.Status;
                survey.Date = model.Survey.Date;

                db.Survey.Update(survey);
                db.SaveChanges();

                TempData["Alert"] = "Success";
                return RedirectToAction(nameof(Edit));
            }
            else
            {
                TempData["Alert"] = "Danger";
                return View(nameof(Edit), new {id});
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
        public IActionResult MySurveys(int? page)
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<Survey> surveys = db.Survey.Where(x => x.UserId == id).ToList();

            int pageSize = 20;
            int pageNumber = (page ?? 1);
            IPagedList<Survey> pageSurvey = surveys.ToPagedList(pageNumber, pageSize);

            return View(pageSurvey);
        }

    }
}
