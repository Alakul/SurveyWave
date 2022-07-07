using SurveyWave.Areas.Identity.Data;
using SurveyWave.Models;
using System.Collections.Generic;

namespace SurveyWave.Models
{
    public class ResponseViewModel
    {
        public Survey Survey { get; set; }
        public Response Response { get; set; }
        public ResponseInfo ResponseInfo { get; set; }

        public List<ResponseInfo> ResponsesInfo { get; set; }
        public List<ResponseViewModel> Responses { get; set; }
        public List<Question> Questions { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
