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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string? firstVar;
        private string? secondVar;
        private char operation;
        private EditString downString;
        public MainWindow()
        {
            operation = ' ';
            downString = new EditString();
            InitializeComponent();
        }

        private void Update()
        {
            firstVar = downString.Input;
            BlokAnswer.Text = firstVar;
        }

        private void Button_num_1(object sender, EventArgs e)
        {
            downString.AddNumber('1');
            Update();
        }

        private void Button_num_2(object sender, EventArgs e)
        {
            downString.AddNumber('2');
            Update();
        }

        private void Button_num_3(object sender, EventArgs e)
        {
            downString.AddNumber('3');
            Update();
        }

        private void Button_num_4(object sender, EventArgs e)
        {
            downString.AddNumber('4');
            Update();
        }

        private void Button_num_5(object sender, EventArgs e)
        {
            downString.AddNumber('5');
            Update();
        }

        private void Button_num_6(object sender, EventArgs e)
        {
            downString.AddNumber('6');
            Update();
        }

        private void Button_num_7(object sender, EventArgs e)
        {
            downString.AddNumber('7');
            Update();
        }

        private void Button_num_8(object sender, EventArgs e)
        {
            downString.AddNumber('8');
            Update();
        }

        private void Button_num_9(object sender, EventArgs e)
        {
            downString.AddNumber('9');
            Update();
        }

        private void Button_num_0(object sender, EventArgs e)
        {
            downString.AddNumber('0');
            Update();
        }

        private void Button_sign(object sender, EventArgs e)
        {
            downString.InvertSign();
            Update();
        }

        private void Button_comma(object sender, EventArgs e)
        {
            downString.AddComma();
            Update();
        }

        private void Button_backspace(object sender, EventArgs e)
        {
            downString.DeletSymb();
            Update();
        }

        private void Button_clear_down(object sender, EventArgs e)
        {
            downString.Clear();
            Update();
        }

        private void ExampleOperation()
        {

        }

        private void Button_plus(object sender, EventArgs e)
        {
            if(firstVar == null)
            {
                secondVar = firstVar;
                firstVar = "";
                downString.Clear();
                operation = '+';
            }
            else
                ExampleOperation();
        }
    }
}
