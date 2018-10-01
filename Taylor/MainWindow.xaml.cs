using System;
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

namespace Taylor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FunctionType functionType;
        string sFunction;
        int sFirstParam, SXParam;

        public MainWindow()
        {
            InitializeComponent();
            comboBoxXFunction.SelectionChanged += ComboBoxXFunction_SelectionChanged;
            textBoxFirstParam.TextChanged += TextBoxFirstParam_TextChanged;
            textBoxX.TextChanged += TextBoxX_TextChanged;

        }

        private void TextBoxX_TextChanged(object sender, TextChangedEventArgs e)
        {
            Int32.TryParse(((TextBox)sender).Text, out SXParam);
            RefreshFunctionLabel();
        }

        private void TextBoxFirstParam_TextChanged(object sender, TextChangedEventArgs e)
        {
            Int32.TryParse(((TextBox)sender).Text, out sFirstParam);
            RefreshFunctionLabel();
        }

        private void RefreshFunctionLabel()
        {
            sFunction = sFirstParam + "*" + functionType.ToString() + "(" + SXParam + "*X)";
            labelFunction.Content = sFunction;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            comboBoxXFunction.ItemsSource = Enum.GetValues(typeof(FunctionType)).Cast<FunctionType>();
            comboBoxXFunction.SelectedIndex = 0;
            Int32.TryParse(textBoxFirstParam.Text, out sFirstParam);
            Int32.TryParse(textBoxX.Text, out SXParam);
            RefreshFunctionLabel();
        }

        private void ComboBoxXFunction_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            functionType = (FunctionType)Enum.Parse(typeof(FunctionType), e.AddedItems[0].ToString());
            RefreshFunctionLabel();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Cosinus cosinus = new Cosinus();
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = MathLogic.Factorial(Int32.Parse(textBox2.Text)).ToString();
        }


    }
}
