using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NETcoreSurveyApp.Models
{
    public class SurveyViewModel
    {
        public Survey Survey { get; set; }
        public Question Question { get; set; }
        public List<Question> Questions { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
