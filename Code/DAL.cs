using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace CVSpider.Code
{ 
    public class DAL
    {
        internal static void CreateEmail(string email)
        {
            using (SqlConnection con = DbUtilsDal.OpenConnection(DbUtilsDal.MainDB))
            {
                DbUtilsDal.ExecuteNonQuery(con, "dbo.CreateEmail",
                           new string[] { "@Email" },
                           new SqlDbType[] { SqlDbType.VarChar },
                           new object[] { email });
            }
        }

        internal static EmailRow GetEmail(string email)
        {
            DataRow row = null;
            using (SqlConnection con = DbUtilsDal.OpenConnection(DbUtilsDal.MainDB))
            {
                row = DbUtilsDal.ExecuteDataRow(con, "dbo.GetEmail",
                                 new string[] { "@Email" },
                                 new SqlDbType[] { SqlDbType.VarChar },
                                 new object[] { email });
            }
            return EmailRow.ToEmailRow(row);
        }

        internal static List<EmailRow> GetCVMails()
        {
            DataTable rows = null;
            using (SqlConnection con = DbUtilsDal.OpenConnection(DbUtilsDal.MainDB))
            {
                rows = DbUtilsDal.ExecuteDataTable(con, "dbo.GetCVMails");
            }
            return EmailRow.ToListEmailRows(rows);
        }

        internal static void UpdateCVMails()
        {
            using (SqlConnection con = DbUtilsDal.OpenConnection(DbUtilsDal.MainDB))
            {
                DbUtilsDal.ExecuteDataTable(con, "dbo.UpdateCVMails");
            }
        }

        internal static string GetUnusedCount()
        {
            string count = string.Empty;
            using (SqlConnection con = DbUtilsDal.OpenConnection(DbUtilsDal.MainDB))
            {
                count = DbUtilsDal.ExecuteDataRow(con, "dbo.GetUnusedCount", new string[] { }, new SqlDbType[] { }, new object[] { })[0].ToString();
            }
            return count;
        }
    }
}