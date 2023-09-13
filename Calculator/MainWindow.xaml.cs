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
        private char? operation;
        private EditString downString;
        public MainWindow()
        {
            downString = new EditString();
            InitializeComponent();
        }

        private void Update()
        {
            firstVar = downString.Input;
            BlockAnswer.Text = firstVar;
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

        private void Button_clear_all(object sender, EventArgs e)
        {
            downString.Clear();
            BlockOperation.Text = string.Empty;
            BlockAnswer.Text = "0";
            secondVar = null;
            firstVar = null;
            operation = null;
        }

        private OutResult ExeсutOperation()
        {
            decimal x;
            decimal y;
            bool conver = decimal.TryParse(firstVar, out y) & decimal.TryParse(secondVar, out x);
            if (!conver)
                return new OutResult("Не удалось конвертировать", false);
            decimal result;

            switch (operation)
            {
                case '+':
                    {
                        if (x + y < decimal.MaxValue)
                            result = x + y;
                        else
                            return new OutResult("Переполнение", false);
                        break;
                    }
                case '-':
                    {
                        if (x - y > decimal.MinValue)
                            result = x - y;
                        else
                            return new OutResult("Переполнение", false);
                        break;
                    }
                case '*':
                    {
                        if (Math.Abs(x * y) > decimal.MaxValue)
                            result = x * y;
                        else
                            return new OutResult("Переполнение", false);
                        break;
                    }
                case '/':
                    {
                        if (y == 0)
                            return new OutResult("Деление на ноль", false);
                        if (Math.Abs(x / y) > decimal.MinValue)
                            result = x / y;
                        else
                            return new OutResult("Переполнение", false);
                        break;
                    }
                default:
                    return new OutResult("Нет такой операции", false);
            }

            return new OutResult(result.ToString(), true);
        }

        private void InputOperation(char operation)
        {
            if (firstVar != null)
            {
                if (secondVar == null)
                {
                    secondVar = firstVar;
                    this.operation = operation;
                    BlockOperation.Text = secondVar + operation;
                    firstVar = null;
                }
                else if(this.operation != null)
                {
                    OutResult input = ExeсutOperation();
                    firstVar = null;
                    secondVar = null;
                    if (input.IsSuccess)
                    {
                        secondVar = input.Result;
                        this.operation = operation;
                        BlockOperation.Text = secondVar + operation;
                        BlockAnswer.Text = secondVar;
                    }
                    else
                    {
                        BlockAnswer.Text = input.ErrorMessage;
                        BlockOperation.Text = string.Empty;
                    }
                }
                else
                {
                    this.operation = operation;
                    BlockOperation.Text = secondVar + operation;
                }
            }
            else if (secondVar != null)
            {
                this.operation = operation;
                BlockOperation.Text = secondVar + operation;
            }
            downString.Clear();
        }

        private void Button_plus(object sender, EventArgs e)
        {
            InputOperation('+');
        }

        private void Button_minus(object sender, EventArgs e)
        {
            InputOperation('-');
        }

        private void Button_multiply(object sender, EventArgs e)
        {
            InputOperation('*');
        }

        private void Button_divide(object sender, EventArgs e)
        {
            InputOperation('/');
        }

        private void Button_equally(object sender, EventArgs e)
        {
            if(operation == null)
            {
                if (firstVar == null)
                    firstVar = "0";
                secondVar = firstVar;
                BlockOperation.Text = firstVar + '=';
                downString.Clear();
            }
            else
            {
                if (secondVar == null)
                {
                    firstVar = downString.Input;
                    secondVar = firstVar;
                    OutResult input = ExeсutOperation();
                    if (input.IsSuccess)
                    {
                        BlockOperation.Text = secondVar + operation + firstVar + '=';
                        firstVar = null;
                        secondVar = null;
                        secondVar = input.Result;
                        BlockAnswer.Text = secondVar;
                    }
                    else
                    {
                        firstVar = null;
                        secondVar = null;
                        BlockAnswer.Text = input.ErrorMessage;
                        BlockOperation.Text = string.Empty;
                    }
                }
                else
                {
                    firstVar = downString.Input;
                    OutResult input = ExeсutOperation();
                    if (input.IsSuccess)
                    {
                        BlockOperation.Text = secondVar + operation + firstVar + '=';
                        firstVar = null;
                        secondVar = null;
                        secondVar = input.Result;
                        BlockAnswer.Text = secondVar;
                    }
                    else
                    {
                        firstVar = null;
                        secondVar = null;
                        BlockAnswer.Text = input.ErrorMessage;
                        BlockOperation.Text = string.Empty;
                    }
                }
            }
        }
    }
}
