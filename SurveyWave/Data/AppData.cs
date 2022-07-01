using System.Collections.Generic;

namespace SurveyWave.Data
{
    public class AppData
    {
        public static Dictionary<string, string> surveySort = new Dictionary<string, string> {
            {"DateAsc", "po dacie dodania rosnąco"},
            {"DateDesc", "po dacie dodania malejąco"},
            {"TitleAsc", "po tytule rosnąco"},
            {"TitleDesc", "po tytule malejąco"},
            {"StartDateAsc", "po dacie otwarcia rosnąco"},
            {"StartDateDesc", "po dacie otwarcia malejąco"},
            {"EndDateAsc", "po dacie zamknięcia rosnąco"},
            {"EndDateDesc", "po dacie zamknięcia malejąco"},
        };

        public static Dictionary<string, string> status = new Dictionary<string, string> {
            {"A", "Wszystkie"},
            {"O", "Otwarte"},
            {"C", "Zamknięte"}
        };
    }
}
