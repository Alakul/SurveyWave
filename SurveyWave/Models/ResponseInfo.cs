using SurveyWave.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyWave.Models
{
    public class ResponseInfo
    {
        public int Id { get; set; }

        [ForeignKey("SurveyId")]
        public int SurveyId { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public List<Response> Response { get; set; }
    }
}
