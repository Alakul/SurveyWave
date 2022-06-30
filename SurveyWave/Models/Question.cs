using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NETcoreSurveyApp.Models
{
    public class Question
    {
        public int Id { get; set; }

        [ForeignKey("SurveyId")]
        public int SurveyId { get; set; }
        public Survey Survey { get; set; }

        public int Number { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }

        public List<Answer> Answers { get; set; }

        [NotMapped]
        public int Index { get; set; }
    }
}
