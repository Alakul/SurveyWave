using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyWave.Models
{
    public class Answer
    {
        public int Id { get; set; }

        [ForeignKey("QuestionId")]
        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public int Number { get; set; }
        public string Text { get; set; }



        public Answer()
        {
            Index = 0;
            QuestionIndex = 0;
            QuestionType = "Radio";
        }

        [NotMapped]
        public int Index { get; set; }

        [NotMapped]
        public int QuestionIndex { get; set; }

        [NotMapped]
        public string QuestionType { get; set; }
    }
}
