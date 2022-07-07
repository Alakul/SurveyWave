using SurveyWave.Data;
using SurveyWave.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace SurveyWave.Controllers
{
    public class ResponseController : Controller
    {
        AppDbContext db;
        public ResponseController(AppDbContext context)
        {
            db = context;
        }

        // GET: ResponsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ResponsController/Details/5
        [Route("WynikiAnkiety/{id}")]
        public ActionResult Details(int id)
        {
            ResponseViewModel responseViewModel = new ResponseViewModel();

            List<ResponseViewModel> responses = db.Survey
                .Join(db.Question, a => a.Id, b => b.SurveyId, (a, b) => new { survey = a, question = b })
                .Join(db.Answer, joined => joined.question.Id, b => b.QuestionId, (joined, b) => new { joined, answer = b })
                .Join(db.Response, joinedTwice => joinedTwice.answer.Id, response => response.AnswerId, (joinedTwice, response) => new { joinedTwice, response })
                .Join(db.ResponseInfo, joinedThrice => joinedThrice.response.ResponseInfoId, responseInfo => responseInfo.Id,
                (joinedThrice, responseInfo) => new ResponseViewModel
                {
                    Survey = joinedThrice.joinedTwice.joined.survey,
                    ResponseInfo = responseInfo,
                    Response = joinedThrice.response,
                })
                .Where(x => x.Survey.Id == id).ToList();

            responseViewModel.Responses = responses;
            responseViewModel.ResponsesInfo = db.ResponseInfo.Where(x => x.SurveyId == id).ToList();
            responseViewModel.Survey = db.Survey.Where(x => x.Id == id).Single();
            responseViewModel.Questions = db.Question.Where(x => x.SurveyId == id).ToList();
            responseViewModel.Answers = db.Answer.ToList();
            
            return View(responseViewModel);
        }

        // GET: ResponsController/Create
        [Route("ZapiszPodejscie")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ResponsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("ZapiszPodejscie")]
        public ActionResult Create(IFormCollection collection, SurveyViewModel model, int id)
        {
            try
            {
                int questions = int.Parse(Request.Form["questions"]);
                for (int i=0; i < questions; i++){
                    string selectedValues = Request.Form["group_" + i].ToString();
                    if (selectedValues == ""){
                        TempData["Alert"] = "Danger";
                        return RedirectToAction(nameof(Details), "Survey", new { id });
                    }
                }

                ResponseInfo responseInfo = new ResponseInfo
                {
                    SurveyId = id,
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    Date = DateTime.Now
                };
                db.ResponseInfo.Add(responseInfo);
                db.SaveChanges();

                for (int i = 0; i < questions; i++)
                {
                    string selectedValues = Request.Form["group_" + i].ToString();
                    string[] selectedList = selectedValues.Split(',');
                    
                    for (int j = 0; j < selectedList.Length; j++)
                    {
                        int selectedId = int.Parse(selectedList[j]);

                        Response response = new Response
                        {
                            ResponseInfoId = responseInfo.Id,
                            AnswerId = selectedId,
                        };
                        db.Response.Add(response);
                        db.SaveChanges();
                    }
                }

                TempData["Alert"] = "Success";
                return RedirectToAction(nameof(Details), "Survey", new { id });
            }
            catch
            {
                TempData["Alert"] = "Danger";
                return RedirectToAction(nameof(Details), "Survey", new { id });
            }
        }

        // GET: ResponsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ResponsController/Edit/5
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

        // GET: ResponsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ResponsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
        public SurveyViewModel GetModel(int id)
        {
            SurveyViewModel surveyViewModel = new SurveyViewModel();
            surveyViewModel.Survey = db.Survey.Where(x => x.Id == id).Single();
            surveyViewModel.Questions = db.Question.Where(x => x.SurveyId == id).ToList();
            surveyViewModel.Answers = db.Answer.ToList();

            return surveyViewModel;
        }
    }
}
