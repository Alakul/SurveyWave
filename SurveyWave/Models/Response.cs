using ASP.NETcoreSurveyApp.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NETcoreSurveyApp.Models
{
    public class Response
    {
        public int Id { get; set; }

        [ForeignKey("AnswerId")]
        public int AnswerId { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }

        public DateTime Date { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
