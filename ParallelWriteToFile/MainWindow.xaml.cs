using System;
using Taylor;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace ParallelWriteToFile
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rnd;
        const int iter = 1000;

        public MainWindow()
        {
            rnd = new Random();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ParallelMethod();

            PosledMethod();

            MessageBox.Show("Готово, смотри файлы");
        }

        private void PosledMethod()
        {
            Stopwatch sw = new Stopwatch();
            Sinus sin = new Sinus();
            SecondCosinus cos = new SecondCosinus();
            Eps epsi = new Eps();
            string path = @"F:\output2.txt";
            using (System.IO.StreamWriter file = System.IO.File.CreateText(path)) { }
            sw.Start();

            for (int a = 0; a < iter; a++)
            {
                int x = rnd.Next(1, 500);
                double result = sin.tailorFactory(x);
                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(path, true))
                {
                    file.WriteLine(
                        "Sinus " +
                        "Значение X: " + x.ToString() + " " +
                        "Значение функции: " + result.ToString()
                        );
                }
            }
            for (int a = 0; a < iter; a++)
            {
                int x = rnd.Next(1, 500);
                double result = cos.tailorFactory(x);
                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(path, true))
                {
                    file.WriteLine(
                        "Cosinus " +
                        "Значение X: " + x.ToString() + " " +
                        "Значение функции: " + result.ToString()
                        );
                }
            }
            for (int a = 0; a < iter; a++)
            {
                double x = rnd.NextDouble() * (-1);
                double result = epsi.tailorFactory(x);
                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(path, true))
                {
                    file.WriteLine(
                        "Eps " +
                        "Значение X: " + x.ToString() + " " +
                        "Значение функции: " + result.ToString()
                        );
                }
            }
            sw.Stop();
            using (System.IO.StreamWriter file =
                                    new System.IO.StreamWriter(path, true))
            {
                file.WriteLine(
                    "Время выполнения в секундах: " + (sw.ElapsedMilliseconds / 1000.0).ToString()
                    );
            }
        }

        private void ParallelMethod()
        {
            Stopwatch sw = new Stopwatch();
            object blocerator = new object();
            Sinus sin = new Sinus();
            SecondCosinus cos = new SecondCosinus();
            Eps epsi = new Eps();
            string path = @"F:\output.txt";
            using (System.IO.StreamWriter file = System.IO.File.CreateText(path)) { }
            sw.Start();
            Parallel.For(0, 3, i =>
            {
                switch (i)
                {
                    case 0:
                        for (int a = 0; a < iter; a++)
                        {
                            int x = rnd.Next(1, 500);
                            double result = sin.tailorFactory(x);
                            lock (blocerator)
                                using (System.IO.StreamWriter file =
                                    new System.IO.StreamWriter(path, true))
                                {
                                    file.WriteLine(
                                        "Sinus " +
                                        "Значение X: " + x.ToString() + " " +
                                        "Значение функции: " + result.ToString()
                                        );
                                }
                        }
                        break;
                    case 1:
                        for (int a = 0; a < iter; a++)
                        {
                            int x = rnd.Next(1, 500);
                            double result = cos.tailorFactory(x);

                            lock (blocerator)
                                using (System.IO.StreamWriter file =
                                    new System.IO.StreamWriter(path, true))
                                {
                                    file.WriteLine(
                                        "Cosinus " +
                                        "Значение X: " + x.ToString() + " " +
                                        "Значение функции: " + result.ToString()
                                        );
                                }
                        }
                        break;
                    case 2:
                        for (int a = 0; a < iter; a++)
                        {
                            double x = rnd.NextDouble() * (-1);
                            double result = epsi.tailorFactory(x);
                            lock (blocerator)
                                using (System.IO.StreamWriter file =
                                    new System.IO.StreamWriter(path, true))
                                {
                                    file.WriteLine(
                                        "Eps " +
                                        "Значение X: " + x.ToString() + " " +
                                        "Значение функции: " + result.ToString()
                                        );
                                }
                        }
                        break;
                }
            });
            sw.Stop();
            using (System.IO.StreamWriter file =
                                    new System.IO.StreamWriter(path, true))
            {
                file.WriteLine(
                    "Время выполнения в секундах: " + (sw.ElapsedMilliseconds / 1000.0).ToString()
                    );
            }
        }
    }
}
