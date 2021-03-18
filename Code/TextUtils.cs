using System;
using System.Net;
using System.Linq;
using System.Net.Mail;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace CVSpider.Code
{
    public static class TextUtils
    {
        //TO BE REMOVED
        //public static int GetRandomNumber(int max)
        //{
        //    Random random = new Random();
        //    return random.Next(1, max);
        //}

        public static int GetRandomNumber(int max)
        {
            int result = 0;
            using (RNGCryptoServiceProvider rngProvider = new RNGCryptoServiceProvider())
            {
                byte[] b = new byte[sizeof(UInt32)];
                rngProvider.GetBytes(b);
                double d = BitConverter.ToUInt32(b, 0) / (double)UInt32.MaxValue;
                result = 0 + (int)((max - 0) * d);
            }
            return result;
        }

        public static List<string> GetUrls(string html)
        {
            List<string> list = null;
            string hRefPattern = "href\\s*=\\s*(?:[\"'](?<1>[^\"']*)[\"']|(?<1>\\S+))";
            Regex regex = new Regex(hRefPattern);
            try
            {
                MatchCollection matches = regex.Matches(html);
                foreach (Match match in matches)
                {
                    string value = match.Value;
                    if (string.IsNullOrEmpty(value))
                    {
                        continue;
                    }

                    if (value.Contains("walla") || value.Contains(".css") || value.Contains("/?q="))
                    {
                        continue;
                    }

                    value = value.Replace("href=", string.Empty);
                    value = value.Replace("href = ", string.Empty);
                    value = value.Replace("\"", string.Empty);
                    value = value.Replace("\\", string.Empty);
                    if (value.Length < 5)
                    {
                        continue;
                    }
                    if (list == null)
                    {
                        list = new List<string>();
                    }
                    list.Add(value);
                }
            }
            catch (Exception) { }
            return list;
        }

        public static string GetPageSource(string url)
        {
            string strSource = string.Empty;
            try
            {
                WebClient webClient = new WebClient();
                strSource = webClient.DownloadString(url);
                webClient.Dispose();
            }
            catch (Exception) { }
            return strSource;
        }

        public static string ClearEmail(string mail)
        {
            //www.shabaton.co.il/drushim/contact_drushim_mefarsem.asp?email=
            int index1 = mail.IndexOf("?email=");
            if (index1 > -1)
            {
                mail = mail.Substring(index1 + 1, mail.Length - (index1 + 1));
            }

            mail = mail.Replace("/", "");
            mail = mail.Replace("\\", "");
            mail = mail.Replace(".co", ".co.il");
            mail = mail.Replace("!", "");
            mail = mail.Replace("'", "");
            mail = mail.Replace("\"", "");
            mail = mail.Replace("?", "");
            mail = mail.Replace(".coil", ".co.il");
            mail = mail.Replace(".ilm", ".il");
            mail = mail.Replace("%", "");
            mail = mail.Replace("|", "");
            mail = mail.Replace("org.i", "org.il");
            mail = mail.Replace("con", "com");
            mail = mail.Replace(".co.ili", ".co.il");
            mail = mail.Replace(".njet", ".net");
            mail = mail.Replace(".net.i", ".net.il");
            mail = mail.Replace(".met", ".net");
            mail = mail.Replace(".co.oil", ".co.il");
            mail = mail.Replace(".ill", ".il");
            mail = mail.Replace(".co.i", ".co.il");
            mail = mail.Replace(".walla.c", ".walla.com");
            mail = mail.Replace(".com2", ".com");
            mail = mail.Replace("@.", "@");
            mail = mail.Replace(".co.ill", ".co.il");
            mail = mail.Replace(".walla.co", ".walla.co.il");
            mail = mail.Replace("gmail.comm", "gmail.com");
            mail = mail.Replace("gmail.com.il", "gmail.com");
            mail = mail.Replace(".org.ill", ".org.il");
            mail = mail.Replace(".gov.i", ".gov.il");
            mail = mail.Replace(".walla.cil", ".walla.co.il");
            mail = mail.Replace("gmail.co", "gmail.com");
            mail = mail.Replace("mailto%20", "");
            mail = mail.Replace("mailto:", "");
            mail = mail.Replace("mailto", "");
            mail = mail.Replace("@ariel.ac.i", "@ariel.ac.il");
            mail = mail.Replace("@nana.co.il", "@nana10.co.il");
            mail = mail.Replace("%20", "");
            mail = mail.Replace(".muni.i", "muni.il");
            mail = mail.Replace("^", "");
            mail = mail.Replace(".netl", ".net");
            mail = mail.Replace(".co.il1", ".co.il");
            mail = mail.Replace(".comcom", ".com");
            mail = mail.Replace(".comm", ".com");
            mail = mail.Replace(".co.ill", ".co.il");
            mail = mail.Replace(".ill", ".il");
            mail = mail.Replace(".co.il.il", ".co.il");
            mail = mail.Replace(".co.il.l", ".co.il");
            mail = mail.Replace(".com.il", ".com");
            mail = mail.Replace(".comn", ".com");
            mail = mail.Replace(".co.il.i", ".co.il");
            mail = mail.Replace(".co.ilcom", ".com");
            mail = mail.Replace(".co.ill", ".co.il");
            mail = mail.Replace("mail.biu.ac.i", "mail.biu.ac.il");
            if (mail.Contains('='))
            {
                mail = mail.Split('=')[1];
            }
            if (mail.Contains(".."))
            {
                mail = string.Join(".", mail.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries));
            }
            if (mail.Contains("@."))
            {
                mail = mail.Replace("@.", "@");
            }

            MailAddress address = new MailAddress(mail);
            if (address.Host == "gmail.c")
            {
                mail = mail.Replace("gmail.c", "gmail.com");
            }

            if (address.Host == "walla.c")
            {
                mail = mail.Replace("@walla.c", "@walla.co.il");
            }

            if (address.Host.Contains(".com"))
            {
                mail = mail.Substring(0, mail.IndexOf(".com") + 4);
            }
            return mail;
        }

        public static bool ValidateMail(string mail)
        {
            if (string.IsNullOrEmpty(mail))
            {
                return false;
            }

            if (mail.StartsWith("www."))
            {
                return false;
            }

            if (!mail.Contains("@") || mail.Contains("$") || mail.Contains("*") || mail.Contains(".jpg") || mail.Contains(".png") || mail.Contains(".."))
            {
                return false;
            }

            string[] splitter1 = mail.Split('.');
            int shtrudelIndex = mail.IndexOf('@');
            foreach(string dotSplit in splitter1)
            {
                if (dotSplit.Length <= 1)
                {
                    if (shtrudelIndex < mail.IndexOf(dotSplit))
                    {
                        return false;
                    }
                }
            }

            string[] splitter2 = mail.Split('@');
            foreach (string mailPart in splitter2)
            {
                if (!string.IsNullOrEmpty(mailPart))
                {
                    if (mailPart.Trim().Length <= 2)
                    {
                        return false;
                    }
                }
            }

            try
            {
                mail = mail.Trim();
                MailAddress m = new MailAddress(mail);
                if (mail.Contains("-"))
                {
                    if (mail.Contains("@-"))
                    {
                        return false;
                    }

                    if (mail.Contains("-."))
                    {
                        int i = mail.IndexOf("-.");
                        int d = mail.IndexOf("@");
                        if (i > d)
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
