using SurveyWave.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyWave.Models
{
    public class Response
    {
        public int Id { get; set; }

        [ForeignKey("ResponseInfoId")]
        public int ResponseInfoId { get; set; }

        [ForeignKey("AnswerId")]
        public int AnswerId { get; set; }
        
    }
}
