﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Taylor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyMatrix matrix1, matrix2;
        FunctionType functionType;
        string sFunction;
        int sFirstParam, sXParam, sXCoef, sN;

        static Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();
            comboBoxXFunction.SelectionChanged += ComboBoxXFunction_SelectionChanged;
            textBoxFirstParam.TextChanged += TextBoxFirstParam_TextChanged;
            textBoxTaylorXCoef.TextChanged += TextBoxX_TextChanged;
            textBoxTaylorN.TextChanged += TextBoxTaylorN_TextChanged;
            textBoxTaylorX.TextChanged += TextBoxTaylorX_TextChanged;
        }

        private void TextBoxTaylorX_TextChanged(object sender, TextChangedEventArgs e)
        {
            Int32.TryParse(((TextBox)sender).Text, out sXParam);
        }

        private void TextBoxTaylorN_TextChanged(object sender, TextChangedEventArgs e)
        {
            Int32.TryParse(((TextBox)sender).Text, out sN);
        }

        private void TextBoxX_TextChanged(object sender, TextChangedEventArgs e)
        {
            Int32.TryParse(((TextBox)sender).Text, out sXCoef);
            RefreshFunctionLabel();
        }

        private void TextBoxFirstParam_TextChanged(object sender, TextChangedEventArgs e)
        {
            Int32.TryParse(((TextBox)sender).Text, out sFirstParam);
            RefreshFunctionLabel();
        }

        private void RefreshFunctionLabel()
        {
            sFunction = sFirstParam + "*" + functionType.ToString() + "(" + sXCoef + "*X)";
            labelFunction.Content = sFunction;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            comboBoxXFunction.ItemsSource = Enum.GetValues(typeof(FunctionType)).Cast<FunctionType>();
            comboBoxXFunction.SelectedIndex = 0;
            Int32.TryParse(textBoxFirstParam.Text, out sFirstParam);
            Int32.TryParse(textBoxTaylorXCoef.Text, out sXCoef);
            Int32.TryParse(textBoxTaylorN.Text, out sN);
            Int32.TryParse(textBoxTaylorX.Text, out sXParam);
            RefreshFunctionLabel();

            int[,] tempMatrix1, tempMatrix2;
            tempMatrix1 = new int[10, 10];
            tempMatrix2 = new int[10, 10];

            Parallel.For(1, 3, i =>
            {
                switch (i)
                {
                    case 1:
                        for (int a = 0; a < 10; a++)
                        {
                            for (int b = 0; b < 10; b++)
                            {
                                tempMatrix1[a, b] = rnd.Next(0, 1000);
                            }
                        }
                        break;
                    case 2:
                        for (int a = 0; a < 10; a++)
                        {
                            for (int b = 0; b < 10; b++)
                            {
                                tempMatrix2[a, b] = rnd.Next(0, 1000);
                            }
                        }
                        break;
                    default:
                        break;
                }
            });

            matrix1 = new MyMatrix(tempMatrix1);
            matrix2 = new MyMatrix(tempMatrix2);

            //MessageBox.Show(matrix1.ToString());
            //MessageBox.Show(matrix2.ToString());

        }

        private void ComboBoxXFunction_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            functionType = (FunctionType)Enum.Parse(typeof(FunctionType), e.AddedItems[0].ToString());
            RefreshFunctionLabel();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            Stopwatch sw = new Stopwatch();
            Stopwatch sw2 = new Stopwatch();
            
            sw.Start();
                Parallel.For(1, 1000000, i => {
                    Cosinus.mainCalc(sN, sXParam, sFirstParam, sXCoef);
                });
            sw.Stop();

            sw2.Start();
                for (int i = 1; i < 1000000; i++)
                {
                    Cosinus.mainCalc(sN, sXParam, sFirstParam, sXCoef);
                }
            sw2.Stop();

            MessageBox.Show("Параллельное выполнение = " +
                (sw.ElapsedMilliseconds / 1000.0).ToString() +
                "сек.\nПоследовательное выполнение = " +
                (sw2.ElapsedMilliseconds / 1000.0).ToString() +
                "сек.\n" +
                "Параллельное в " +
                ((sw2.ElapsedMilliseconds / 100.0) / (sw.ElapsedMilliseconds / 100.0)).ToString() +
                " раз быстрее");
            sw.Reset();
            this.Cursor = Cursors.Arrow;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = MathLogic.Factorial(Int32.Parse(textBox2.Text)).ToString();
        }


    }
}
