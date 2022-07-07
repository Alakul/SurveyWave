using SurveyWave.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyWave.Models
{
    public class SurveyViewModel
    {
        public Survey Survey { get; set; }
        public Question Question { get; set; }
        public AppUser User { get; set; }

        public List<Question> Questions { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
