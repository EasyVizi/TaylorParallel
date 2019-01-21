using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LabThreads3
{
    class Sites
    {
        double iter = 1;
        Stopwatch swGlobal;
        
        public Sites()
        {
            swGlobal = new Stopwatch();
        }

        public void AsyncTask(string url)
        {
            Uri uri = new Uri(url);
            HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(uri);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        }

        public async void AsyncFunc(string url)
        {
            Stopwatch sw = new Stopwatch();
            if (iter == 1)
            {
                swGlobal.Start();
            }
            sw.Start();
            await Task.Run(() => AsyncTask(url)); // выполняется асинхронно
            sw.Stop();
            Console.WriteLine("Асинхронный запрос к сайту " + url + ", Время выполнения:" + (sw.ElapsedMilliseconds / 1000.0).ToString());
            
            if (iter == 4)
            {
                swGlobal.Stop();
                Console.WriteLine("Общее время выполнения асинхронных запросов:" + (swGlobal.ElapsedMilliseconds / 1000.0).ToString());
            }
            iter++;
        }

        public void SyncFunc(string url)
        {
            Stopwatch st = new Stopwatch();
            st.Start();
            AsyncTask(url);
            st.Stop();
            Console.WriteLine("Синхронный запрос к сайту " + url + ", Время выполнения:" + (st.ElapsedMilliseconds / 1000.0).ToString());
        }
    }
}
