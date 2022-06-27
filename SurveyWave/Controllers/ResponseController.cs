using ASP.NETcoreSurveyApp.Data;
using ASP.NETcoreSurveyApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ASP.NETcoreSurveyApp.Controllers
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
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ResponsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ResponsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, SurveyViewModel model)
        {
            try
            {
                string selected = Request.Form["selected"].ToString();
                string[] selectedList = selected.Split(',');

                for (int i=0; i<selectedList.Length; i++)
                {
                    int selectedId = int.Parse(selectedList[i]);
                    //IEnumerable<int> selectedAnswers = model.QuestionList[i].Answers.Where(x => x.IsSelected == true).Select(x => x.Id);
                    
                    Response response = new Response
                    {
                        AnswerId = selectedId,
                        UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                        Date = DateTime.Now,
                    };
                    db.Response.Add(response);
                    db.SaveChanges();
                    
                }
                return RedirectToAction("Create", "Survey");
            }
            catch
            {
                return View();
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
    }
}
