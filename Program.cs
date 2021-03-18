using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using CVSpider.Code;

namespace CVSpider
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write(
@"Select action:
-------------
1 - Search by random words - Multi threads
2 - Search by random words - Single threads
3 - Print mails
");

            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Console.Write($"Start searching...{ Environment.NewLine }");
                    Parallel.For(0, 10, new ParallelOptions { MaxDegreeOfParallelism = 6 }, count =>
                    {
                        Actions.RandomWordsSearch();
                    });
                    break;
                case 2:
                    Console.Write($"Start searching...{ Environment.NewLine }");
                    Actions.RandomWordsSearch();
                    break;
                case 3:
                    Actions.PrintMails();
                    break;
            }
            Console.Read();
        }
    }
}