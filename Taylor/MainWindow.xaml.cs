using System;
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
using Taylor.Views;

namespace Taylor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            TaylorWindow taylorWindow = new TaylorWindow();
            taylorWindow.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MatrixWindow matrixWindow = new MatrixWindow();
            matrixWindow.Show();
        }
    }
}
