using ASP.NETcoreSurveyApp.Models;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using static SurveyWave.Data.SortEnum;

namespace Biblioteczka.Data
{
    public static class AppMethods
    {
        public static Tuple<List<Survey>, string> Search(IHttpContextAccessor httpContextAccessor, List<Survey> elements, string cookieName, string formValue, string searchString)
        {
            string cookie = httpContextAccessor.HttpContext.Request.Cookies[cookieName];
            string viewSearchString = "";

            if (formValue == null){
                if (cookie != null){
                    elements = GetElementsSearch(elements, cookie);
                    viewSearchString = cookie;
                }
                else {
                    elements = elements.ToList();
                    viewSearchString = "";
                }
            }
            else if (searchString == null && formValue == "1"){
                elements = elements.ToList();
                httpContextAccessor.HttpContext.Response.Cookies.Delete(cookieName);
                viewSearchString = "";
            }
            else if (searchString != null && formValue == "1"){
                string newValue = searchString.Trim();
                if (!string.IsNullOrEmpty(newValue)){
                    if (newValue != cookie){
                        httpContextAccessor.HttpContext.Response.Cookies.Append(cookieName, newValue);
                    }
                    elements = GetElementsSearch(elements, newValue);
                    viewSearchString = newValue;
                }
                else {
                    elements = elements.ToList();
                    viewSearchString = "";
                }
            }
            return Tuple.Create(elements, viewSearchString);
        }
        private static List<Survey> GetElementsSearch(List<Survey> elements, string cookie)
        {
            elements = elements.Where(x => x.Title.ToLower().Contains(cookie.ToLower())).ToList();
            return elements;
        }

        public static List<Survey> Sort(IHttpContextAccessor httpContextAccessor, List<Survey> elements, string cookieName, string sortOrder)
        {
            string cookie = httpContextAccessor.HttpContext.Request.Cookies[cookieName];

            if (sortOrder == null){
                if (cookie != null){
                    SortValues sortValue = (SortValues)Enum.Parse(typeof(SortValues), cookie, true);
                    elements = SortElements(elements, sortValue);
                }
            }
            else if (sortOrder != null){
                httpContextAccessor.HttpContext.Response.Cookies.Append(cookieName, sortOrder);
                SortValues sortValue = (SortValues)Enum.Parse(typeof(SortValues), sortOrder, true);
                elements = SortElements(elements, sortValue);
            }

            return elements;
        }
        public static List<Survey> SortElements(List<Survey> elements, SortValues sortValues) =>
        sortValues switch
        {
            SortValues.TitleAsc => elements = elements.OrderBy(x => x.Title).ToList(),
            SortValues.TitleDesc => elements = elements.OrderByDescending(x => x.Title).ToList(),
            SortValues.DateAsc => elements = elements.OrderBy(x => x.Date).ToList(),
            SortValues.DateDesc => elements = elements.OrderByDescending(x => x.Date).ToList(),
            SortValues.StartDateAsc => elements = elements.OrderBy(x => x.StartDate).ToList(),
            SortValues.StartDateDesc => elements = elements.OrderByDescending(x => x.StartDate).ToList(),
            SortValues.EndDateAsc => elements = elements.OrderBy(x => x.EndDate).ToList(),
            SortValues.EndDateDesc => elements = elements.OrderByDescending(x => x.EndDate).ToList(),
            _ => elements = elements.OrderByDescending(x => x.Date).ToList(),
        };

        public static List<Survey> SelectStatus(IHttpContextAccessor httpContextAccessor, List<Survey> surveys, string cookieName, string selectStatus)
        {
            string cookie = httpContextAccessor.HttpContext.Request.Cookies[cookieName];

            if (selectStatus == null){
                if (cookie != null && cookie != "A"){
                    surveys = surveys.Where(x => x.Status == cookie).ToList();  
                }
            }
            else if (selectStatus != null){
                httpContextAccessor.HttpContext.Response.Cookies.Append(cookieName, selectStatus);
                if (selectStatus != "A"){
                    surveys = surveys.Where(x => x.Status == selectStatus).ToList();
                }
            }

            return surveys;
        }
        public static string SetViewData(IHttpContextAccessor httpContextAccessor, string value, string cookieName, string defaulValue)
        {
            if (value == null){
                string cookie = httpContextAccessor.HttpContext.Request.Cookies[cookieName];
                if (cookie == null){
                    return defaulValue;
                }
                else {
                    return cookie;
                }
            }
            else {
                return value;
            }
        }
    }
}
