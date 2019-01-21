using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabThreads3
{
    class Program
    {
        static void Main(string[] args)
        {
            Sites s = new Sites();
            string[] url = new string[] { "https://vk.com/", "https://ya.ru/", "https://habr.com/", "https://www.google.ru" };

            Stopwatch sw = new Stopwatch();
            sw.Start();
            foreach (string ssylka in url)
            {
                s.SyncFunc(ssylka);
            }
            sw.Stop();
            Console.WriteLine("Общее время выполнения: " + (sw.ElapsedMilliseconds / 1000.0).ToString());

            foreach (string ssylka in url)
            {
                s.AsyncFunc(ssylka);
            }
            Console.ReadLine();
        }


    }
}
