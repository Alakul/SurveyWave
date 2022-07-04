using SurveyWave.Areas.Identity.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyWave.Models
{
    public class Survey
    {
        public Survey()
        {
            Questions = new List<Question>();
        }

        public int Id { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Pole {0} jest wymagane.")]
        [Display(Name = "Tytuł")]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "Pole {0} musi mieć co najmniej {2} i maksymalnie {1} znaków.", MinimumLength = 2)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Pole {0} jest wymagane.")]
        [Display(Name = "Opis")]
        [DataType(DataType.Text)]
        [StringLength(1000, ErrorMessage = "Pole {0} musi mieć co najmniej {2} i maksymalnie {1} znaków.", MinimumLength = 2)]
        public string Description { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Pole {0} jest wymagane.")]
        [Display(Name = "Data otwarcia")]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Pole {0} jest wymagane.")]
        [Display(Name = "Data zamknięcia")]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }

        public List<Question> Questions { get; set; }

        public bool IsActive
        {
            get { return StartDate < DateTime.Now && EndDate > DateTime.Now; }
        }
    }
}
