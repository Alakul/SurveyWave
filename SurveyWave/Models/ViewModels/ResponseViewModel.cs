using System.Collections.Generic;

namespace ASP.NETcoreSurveyApp.Models
{
    public class ResponseViewModel
    {
        public Survey Survey { get; set; }
        public Response Response { get; set; }
        public List<ResponseViewModel> Responses { get; set; }
        public List<Question> Questions { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
