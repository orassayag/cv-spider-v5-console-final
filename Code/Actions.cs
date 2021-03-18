using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CVSpider.Code
{
    public class Actions
    {
        public Actions() { }

        public static void RandomWordsSearch()
        {
            Console.Title = BLL.GetUnusedCount();
            Search();
        }

        public static void Search()
        {
            int startIndex = int.Parse(ConfigurationManager.AppSettings["StartIndex"]);
            int endIndex = int.Parse(ConfigurationManager.AppSettings["EndIndex"]);

            int counter = 0;
            for (int i = startIndex; i < endIndex; i++)
            {
                string querySearch = Lists.GetRandomQuerySearch();
                List<string> urls = null;
                Random pageRandom = new Random();
                for (int y = 1; y < 10; y++)
                {
                    string query = $"http://www.ask.com/web?q={ querySearch }&page={ y }&qid=2FB769BA4261894246E81995BA96F6B6&o=0&l=dir&qsrc=998&qo=pagination";
                    string pageSource = TextUtils.GetPageSource(query);
                    urls = TextUtils.GetUrls(pageSource);
                    if (urls != null)
                    {
                        urls = urls.Where(u => u.IndexOf("ask.com") == -1).ToList();
                        foreach (string u in urls)
                        {
                            if (!string.IsNullOrEmpty(u))
                            {
                                counter += GetMails(u);
                            }
                        }
                    }
                }
            }
        }

        public static int GetMails(string source)
        {
            int count = 0;
            string htmlMatch = TextUtils.GetPageSource(source);
            if (string.IsNullOrEmpty(htmlMatch))
            {
                return 0;
            }

            Regex regex = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
            MatchCollection matches = regex.Matches(htmlMatch);
            foreach (Match match in matches)
            {
                bool isValid = TextUtils.ValidateMail(match.Value);
                if (isValid)
                {
                    string email = match.Value.Trim().ToLower();
                    email = TextUtils.ClearEmail(email);
                    EmailRow emailRow = BLL.GetEmail(email);
                    if (emailRow == null)
                    {
                        if (CreateEmail(email))
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }

        public static bool CreateEmail(string email)
        {
            int maxRetries = 10;
            int retriesCount = 0;
            bool success = false;
            while (!success && retriesCount < maxRetries)
            {
                try
                {
                    retriesCount++;
                    Console.WriteLine(email);
                    BLL.CreateEmail(email);
                    success = true;
                    Console.Title = BLL.GetUnusedCount();
                }
                catch (Exception) { }
            }
            return success;
        }

        public static void PrintMails()
        {
            Console.WriteLine("Start printing mails...");
            try
            {
                int counter = 0;
                StringBuilder writer = new StringBuilder();
                List<EmailRow> mails = BLL.GetCVMails();
                foreach (EmailRow mail in mails)
                {
                    counter++;
                    writer.Append($"{ mail.Email }, ");
                }
                writer = writer.Remove(writer.Length - 1, 1);
                using (StreamWriter streamWriter = new StreamWriter(ConfigurationManager.AppSettings["LogMailsPath"], true))
                {
                    streamWriter.WriteLine(writer.ToString());
                }
                BLL.UpdateCVMails();
            }
            catch
            {
                Console.WriteLine("Failed to print mails...");
                return;
            }
            Console.WriteLine("Finish to print mails...");
        }
    }
}

#region Old Code

//using System.Threading;

//string query = $"https://www.bing.com/search?q={ querySearch }&go=Submit&qs=n&pq={ querySearch }&sc=0-0&sp=-1&sk=&cvid=EBBD7B08E1BA420A82CCB5C065660AF9&first={ (y * 10) + 1 }&FORM=PORE";
//urls = urls.Where(u => u.IndexOf("search?q=") == -1 && u.IndexOf("go.microsoft") == -1 && u.IndexOf("/") > 0).ToList();
//if (urls.Count < 2)
//{
//    break;
//}

//string query = $"https://www.google.co.il/search?q={ querySearch }&ei=v4S7VsiWGsucsgG6-YPwCA&start={ y * 10 }&sa=N&biw=1920&bih=955";
//urls = urls.Where(u => u.IndexOf("google") == -1).Select(u => u.Replace("&amp;", "&")).ToList();
//urls = urls.Where(u => u.IndexOf("/url?q=") > -1).Select(u => u.Substring(0, u.IndexOf("&sa="))).ToList();

//string query = $"http://www.ask.com/web?q={ querySearch }&page={ y }&qid=2FB769BA4261894246E81995BA96F6B6&o=0&l=dir&qsrc=998&qo=pagination";
//string query = $"http://search.aol.com/aol/search?s_chn=prt_bon11&page={ y }&v_t=comsearch&enabled_terms=&q={ querySearch }&s_it=comsearch&oreq=23e4b4d1bef44f0f89782a46a32ab4e1";
//string query = $"https://search.yahoo.com/search;_ylt=AwrBT9YzBrlWxQYAikdXNyoA;_ylu=X3oDMTEzajVvczlrBGNvbG8DYmYxBHBvcwMxBHZ0aWQDBHNlYwNwYWdpbmF0aW9u?p={ querySearch }fr=altavista&fr2=sb-top-search&b={ y * 10 }&pz=10&bct=0&xargs=0";
//string query = $"http://search.walla.co.il/?q={ querySearch }&type=text&page={ y }";


//int end = pageRandom.Next(1, 3);
//int start = pageRandom.Next(1, end);
//string query = $"https://www.bing.com/search?q={ querySearch }&go=Submit&qs=n&sc=0-0&sp=-1&sk=&cvid=EBBD7B08E1BA420A82CCB5C065660AF9&first={ (y * 10) + 1 }&FORM=PORE";
//string query = $"http://www.ask.com/web?q={ querySearch }&page={ y }&qid=2FB769BA4261894246E81995BA96F6B6&o=0&l=dir&qsrc=998&qo=pagination";

#endregion