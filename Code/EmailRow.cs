using System.Data;
using System.Collections.Generic;

namespace CVSpider.Code
{
    public class EmailRow
    {
        public long Id { get; set; }
        public string Email { get; set; }

        public EmailRow() { }

        public static List<EmailRow> ToListEmailRows(DataTable table)
        {
            List<EmailRow> emailsList = null;
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    emailsList = new List<EmailRow>(table.Rows.Count);
                    foreach(DataRow row in table.Rows)
                    {
                        emailsList.Add(ToEmailRow(row));
                    }
                }
            }
            return emailsList;
        }

        public static EmailRow ToEmailRow(DataRow row)
        {
            EmailRow email = null;
            if (row != null)
            {
                email = new EmailRow();
                if (row["Email"] != null)
                {
                    if (!string.IsNullOrEmpty(row["Email"].ToString()))
                    {
                        email.Email = row["Email"].ToString();
                    }
                }
            }
            return email;
        }
    }
}