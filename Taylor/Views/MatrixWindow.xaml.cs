using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace Taylor.Views
{
    /// <summary>
    /// Логика взаимодействия для MatrixWindow.xaml
    /// </summary>
    public partial class MatrixWindow : Window
    {
        static Random rnd = new Random();
        int[,] tempMatrix1, tempMatrix2;

        public MatrixWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            Stopwatch sw = new Stopwatch();
            Stopwatch sw2 = new Stopwatch();

            tempMatrix1 = new int[10000, 10000];
            tempMatrix2 = new int[10000, 10000];

            Parallel.For(1, 3, i =>
            {
                switch (i)
                {
                    case 1:
                        for (int a = 0; a < 10000; a++)
                        {
                            for (int b = 0; b < 10000; b++)
                            {
                                tempMatrix1[a, b] = rnd.Next(500, 1000);
                            }
                        }
                        break;
                    case 2:
                        for (int a = 0; a < 10000; a++)
                        {
                            for (int b = 0; b < 10000; b++)
                            {
                                tempMatrix2[a, b] = rnd.Next(500, 1000);
                            }
                        }
                        break;
                    default:
                        break;
                }
            });

            this.Cursor = Cursors.Arrow;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;

            Stopwatch sw = new Stopwatch();
            Stopwatch sw2 = new Stopwatch();

            sw.Start();
            int[,] temp = new int[tempMatrix1.GetLength(0), tempMatrix1.GetLength(1)];
            temp = MyMatrix.ParallelPlusMatrix(tempMatrix1, tempMatrix2);
            sw.Stop();

            sw2.Start();
            int[,] temp2 = new int[tempMatrix2.GetLength(0), tempMatrix2.GetLength(1)];
            temp2 = MyMatrix.PlusMatrix(tempMatrix1, tempMatrix2);
            sw2.Stop();

            //MessageBox.Show(MyMatrix.ToString(temp));
            //MessageBox.Show(MyMatrix.ToString(temp2));

            MessageBox.Show("Параллельное выполнение = " +
                (sw.ElapsedMilliseconds / 1000.0).ToString() +
                "сек.\nПоследовательное выполнение = " +
                (sw2.ElapsedMilliseconds / 1000.0).ToString() +
                "сек.\n" +
                "Параллельное в " +
                ((sw2.ElapsedMilliseconds / 100.0) / (sw.ElapsedMilliseconds / 100.0)).ToString() +
                " раз быстрее");

            this.Cursor = Cursors.Arrow;
        }
    }
}
