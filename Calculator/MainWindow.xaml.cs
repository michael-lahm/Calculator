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
        EditString downString;
        public MainWindow()
        {
            downString = new EditString();
            InitializeComponent();
        }

        private void Update()
        {
            string text = downString.Input;
            if (text.Length > 10)
            {
                BlokAnswer.Text = text;
            }
            else
                BlokAnswer.Text = text;
        }

        internal class EditString
        {
            private string input;
            public string Input 
            { 
                get
                {
                    if(sign)
                        return '-' + input;
                    else 
                        return input;
                }
                private set { input = value; }
            }
            private bool comma;
            private bool sign;
            internal EditString()
            {
                comma = false;
                sign = false;
                input = "0";
            }

            internal void AddNumber(char symb)
            {
                if(input.Length < 20)
                {
                    if (symb != '0')
                    {
                        if (input.Length == 1 && input[0] == '0')
                            input = symb + "";
                        else
                            input += symb;
                    }
                    else if (comma == true || input[0] != '0')
                        input += symb;
                }
            }

            internal void AddComma()
            {
                if (comma != true)
                    input += ',';
            }

            internal void InvertSign()
            {
                if (input.Length > 1 || input[0] != '0') 
                { 
                    if(sign)
                        sign = false;
                    else
                        sign = true;
                }
            }

            internal void DeletSymb()
            {
                if (input.Length == 1)
                    Clear();
                else
                    input.Remove(input.Length - 1);
            }

            internal void Clear()
            {
                sign = false;
                input = "0";
            }
        }

        private void Button_num_1(object sender, System.EventArgs e)
        {
            downString.AddNumber('1');
            Update();
        }

        private void Button_num_2(object sender, System.EventArgs e)
        {
            downString.AddNumber('2');
            Update();
        }

        private void Button_num_3(object sender, System.EventArgs e)
        {
            downString.AddNumber('3');
            Update();
        }

        private void Button_num_4(object sender, System.EventArgs e)
        {
            downString.AddNumber('4');
            Update();
        }

        private void Button_num_5(object sender, System.EventArgs e)
        {
            downString.AddNumber('5');
            Update();
        }

        private void Button_num_6(object sender, System.EventArgs e)
        {
            downString.AddNumber('6');
            Update();
        }

        private void Button_num_7(object sender, System.EventArgs e)
        {
            downString.AddNumber('7');
            Update();
        }

        private void Button_num_8(object sender, System.EventArgs e)
        {
            downString.AddNumber('8');
            Update();
        }

        private void Button_num_9(object sender, System.EventArgs e)
        {
            downString.AddNumber('9');
            Update();
        }

        private void Button_num_0(object sender, System.EventArgs e)
        {
            downString.AddNumber('0');
            Update();
        }

        private void Button_sign(object sender, System.EventArgs e)
        {
            downString.InvertSign();
            Update();
        }

        private void Button_comma(object sender, System.EventArgs e)
        {
            downString.AddComma();
            Update();
        }

        private void Button_backspace(object sender, System.EventArgs e)
        {
            downString.DeletSymb();
            Update();
        }

        private void Button_clear(object sender, System.EventArgs e)
        {
            downString.Clear();
            Update();
        }
    }
}
