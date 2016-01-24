using System.Linq;
using System.Collections.Generic;

namespace CVSpider.Code
{
    public class Lists
    {
        public Lists() { }

        private static List<string> CitiesList
        {
            get
            {
                return new List<string>()
                {
                    "עמק-חפר",
                    "עמק חפר",
                    "כפר-סבא",
                    "כפר סבא",
                    "רעננה",
                    "ראש העין",
                    "ראש-העין",
                    "רמות השבים",
                    "רמות-השבים",
                    "הרצליה",
                    "רמת השרון",
                    "רמת-השרון",
                    "פתח תקווה",
                    "פתח-תקווה",
                    "הוד השרון",
                    "הוד-השרון",
                    "פרדסיה",
                    "נתניה",
                    "אבן-יהודה",
                    "אבן יהודה",
                    "צופית",
                    "כפר יונה",
                    "כפר-יונה",
                    "צורן",
                    "קדימה",
                    "כוכב יאיר",
                    "כוכב-יאיר",
                    "צור יגאל",
                    "צור יגאל",
                    "בני דרור",
                    "שדה ורבורג",
                    "שפיים",
                    "תנובות",
                    "ינוב",
                    "גבעת-חן",
                    "בית-ינאי",
                    "ארסוף",
                    "בני ציון",
                    "הרצליה פיתוח",
                    "אודים",
                    "תל יצחק",
                    "תל-מונד",
                    "רשפון",
                    "קדימה-צורן",
                    "ניר אליהו",
                    "נירית",
                    @"כפ""ס",
                    @"פ""ת"
                };
            }
        }

        private static List<string> MailTypesList
        {
            get
            {
                return new List<string>()
                {
                    "מייל",
                    "אי-מייל",
                    @"דוא""ל",
                    "דואר אלקטרוני",
                    "Email",
                    "e-mail",
                    "דואל",
                    "דואר-אלקטרוני"
                };
            }
        }

        private static List<string> ProfessionsList
        {
            get
            {
                return new List<string>()
                {
                    "רכזת פרוייקטים",
                    "מנהלת אדמיניסטרטיבית",
                    "מנהל/ת תפעול",
                    "מנהלת רכש",
                    "אשת יחסי ציבור",
                    "רכזת משאבי אנוש",
                    "מזכירה",
                    "מנהלת משאבי אנוש",
                    "פקידת",
                    "פקידת קבלה",
                    "מתאמת",
                    "אדמיניסטרציה",
                    "כוח אדם",
                    "אחראית ניהול מלאי",
                    "ניהול משרד",
                    "מנהלת השתלמויות",
                    "מנהלת צוות",
                    "פקידת גבייה",
                    "פקידת ביטוח",
                    "אחראית ניהול",
                    "אחראית רכש",
                    "פקידת רכש",
                    "מנהלת תפעול",
                    "מנהלת הדרכה",
                    "מנהלת חשבונות",
                    "מנהלת משרד",
                    "אחראית משרד",
                    "פקידת משרד",
                    "מנהלת שיווק",
                    "אחראית שיווק",
                    "פקידת שיווק",
                    "ייבוא וייצוא",
                    "מנהלת פרוייקטים",
                    "אחראית משאבי אנוש",
                    "פקידת עורך דין",
                    "מזכירת עורך דין",
                    "אחראית כספים",
                    "מנהלת כספים",
                    "מזכירות",
                    "פקידת ייבוא",
                    "פקידת ייצוא",
                    "פקידת מחסן",
                    "פקידת מחסן רכש",
                    "רכזת עמדה",
                    "פקידה במחלקת חשבונות",
                    "פקידת דוקומנטים",
                    "פקידה זמנית",
                    @"מזכירת מנכ""ל",
                    "מזכירה רפואית",
                    "פקידת מוקד",
                    "מנהלת מוקד",
                    "מתאמת פגישות",
                    "מתאמת מכירות",
                    "פקידת שטח",
                    "מזכירת ערב",
                    "מזכירה למשרד",
                    @"פקידה למזכירת מנכ""ל",
                    "רכזת עמדה",
                    "פקידת משלוחים",
                    "אחראית תפעול",
                    "מזכירת שיווק",
                    "מנהלת בק אופיס",
                    "אחראית ייבוא",
                    "אחראית ייצוא",
                    "מוקדנית",
                    "מזכירת הנהלה",
                    @"מזכירת משנה למנכ""ל",
                    "עובדת אדמיניסטרציה",
                    "רפרנטית שירות",
                    "רכזת משאבי אנוש",
                    "מזכירה לאגף שיקומי",
                    "מתאמת אספקות",
                    "מזכירה אישית",
                    "מזכירת מטה",
                    "מזכירת סניף",
                    "מנהלת סניף",
                    "אחראית סניף",
                    "רכזת סניף"
               };
            }
        }

        private static List<string> AskList
        {
            get
            {
                return new List<string>()
                {
                    "חברת צור קשר",
                    "חברת בע''מ",
                    "חברה לישראל",
                    "חברת כוח אדם",
                    "תעסוקה",
                    "דרושים איזור השרון",
                    "דרושות איזור השרון",
                    "משרד כוח האדם",
                    "מנהלת אדמיניסטרציה",
                    "מנהלת משאבי אנוש",
                    "מחלקת גיוס עובדים",
                    "איזור השרון דרושים",
                    "איזור השרון דרושות",
                    "חברת השמה",
                    "דרושה מזכירה",
                    "דרושה עובדת",
                    "דרושה"
                };
            }
        }

        private static string GetRandomWord(string type)
        {
            string word = string.Empty;
            switch (type)
            {
                case "city":
                    List<string> citiesList = CitiesList;
                    word = citiesList.ElementAt(TextUtils.GetRandomNumber(citiesList.Count));
                    break;
                case "mail":
                    List<string> mailTypes = MailTypesList;
                    word = mailTypes.ElementAt(TextUtils.GetRandomNumber(mailTypes.Count));
                    break;
                case "profession":
                    List<string> professionsList = ProfessionsList;
                    word = professionsList.ElementAt(TextUtils.GetRandomNumber(professionsList.Count));
                    break;
                case "ask":
                    List<string> askList = AskList;
                    word = askList.ElementAt(TextUtils.GetRandomNumber(AskList.Count));
                    break;
            }
            return word;
        }

        public static string GetRandomQuerySearch()
        {
            return $"דרושה { GetRandomWord("profession") } ב{ GetRandomWord("city") } { GetRandomWord("mail") }".Replace(" ", "+");
        }
    }
}