using System.Collections.Generic;

namespace SurveyWave.Data
{
    public class AppData
    {
        public static Dictionary<string, string> surveySort = new Dictionary<string, string> {
            {"DateAsc", "Po dacie dodania rosnąco"},
            {"DateDesc", "Po dacie dodania malejąco"},
            {"TitleAsc", "Po tytule rosnąco"},
            {"TitleDesc", "Po tytule malejąco"},
            {"StartDateAsc", "Po dacie otwarcia rosnąco"},
            {"StartDateDesc", "Po dacie otwarcia malejąco"},
            {"EndDateAsc", "Po dacie zamknięcia rosnąco"},
            {"EndDateDesc", "Po dacie zamknięcia malejąco"},
        };

        public static Dictionary<string, string> status = new Dictionary<string, string> {
            {"A", "Wszystkie"},
            {"O", "Otwarte"},
            {"C", "Zamknięte"}
        };
    }
}
