using System.Collections.Generic;

namespace CVSpider.Code
{
    public class BLL
    {
        public static void CreateEmail(string email)
        {
            DAL.CreateEmail(email);
        }

        public static EmailRow GetEmail(string email)
        {
            return DAL.GetEmail(email);
        }

        public static List<EmailRow> GetCVMails()
        {
            return DAL.GetCVMails();
        }

        public static void UpdateCVMails()
        {
            DAL.UpdateCVMails();
        }

        public static string GetUnusedCount()
        {
            return DAL.GetUnusedCount();
        }
    }
}