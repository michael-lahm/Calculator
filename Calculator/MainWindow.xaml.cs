using System;
using System.Windows;
using System.Windows.Controls;

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

        private void UpdateFirst()
        {
            firstVar = downString.Input;
            if (firstVar != null)
                BlockAnswer.Text = firstVar;
            else
            {
                if(operation != null)
                    BlockOperation.Text = secondVar + operation;
                BlockAnswer.Text = "0";
            }
        }

        private void Button_num(object sender, EventArgs e)
        {
            char numInButton = ((TextBlock)((Viewbox)((Button)sender).Content).Child).Text[0];
            downString.AddNumber(numInButton);
            UpdateFirst();
        }

        private void Button_sign(object sender, EventArgs e)
        {
            if(downString.Input != null)
            {
                downString.InvertSign();
                UpdateFirst();
            }
        }

        private void Button_comma(object sender, EventArgs e)
        {
            downString.AddComma();
            UpdateFirst();
        }

        private void Button_backspace(object sender, EventArgs e)
        {
            if(downString.Input != null)
            {
                downString.DeletSymb();
                UpdateFirst();
            }
        }

        private void Button_clear_down(object sender, EventArgs e)
        {
            downString.Clear();
            UpdateFirst();
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
            decimal result;
            bool conver = decimal.TryParse(firstVar, out y) & decimal.TryParse(secondVar, out x);
            if (!conver)
                return new OutResult("Не удалось конвертировать", false);

            switch (operation)
            {
                case '+':
                    {
                        if ((x > 0 && y > decimal.MaxValue - x) || (x < 0 && y < decimal.MinValue - x))
                            return new OutResult("Переполнение", false);

                        result = x + y;
                        break;
                    }
                case '-':
                    {
                        if ((x > 0 && y < decimal.MinValue + x) || (x < 0 && y > decimal.MaxValue + x))
                            return new OutResult("Переполнение", false);

                        result = x - y;
                        break;
                    }
                case '*':
                    {
                        if (Math.Abs(y) > 1 &&
                            Math.Abs(x) > decimal.MaxValue / Math.Abs(y))
                        {
                            return new OutResult("Переполнение", false);
                        }

                        result = x * y;
                        break;
                    }
                case '/':
                    {
                        if (y == 0)
                            return new OutResult("Деление на ноль", false);
                        if (Math.Abs(y) < 1 &&
                            Math.Abs(x) > decimal.MaxValue * Math.Abs(y))
                        {
                            return new OutResult("Переполнение", false);
                        }

                        result = x / y;
                        break;
                    }
                default:
                    return new OutResult("Нет такой операции", false);
            }

            return new OutResult(result.ToString(), true);
        }

        private void ErrorMessage(string error)
        {
            firstVar = null;
            secondVar = null;
            operation = null;
            BlockAnswer.Text = error;
            BlockOperation.Text = string.Empty;
        }

        private string DelExtraSymb(string str) 
        {
            if(!str.Contains(','))
                return str;

            for(int i = str.Length - 1; i > 0; i--)
            {
                if (str[i] == ',')
                {
                    str = str.Remove(str.Length - 1);
                    break;
                }
                if (str[i] == '0' || str[i] == ',')
                    str = str.Remove(str.Length - 1);
                else
                    break;
            }
            return str;
        }

        private void Button_operator(object sender, EventArgs e)
        {
            char operInButton = ((TextBlock)((Viewbox)((Button)sender).Content).Child).Text[0];

            if(secondVar == null)
            {
                if (firstVar == null)
                    secondVar = "0";
                else
                {
                    firstVar = DelExtraSymb(firstVar);
                    BlockAnswer.Text = firstVar;
                    secondVar = firstVar;
                }
                operation = operInButton;
                BlockOperation.Text = secondVar + operation;
            }
            else
            {
                if (operation != null && downString.Input != null)
                    {
                    OutResult input = ExeсutOperation();
                    firstVar = null;
                    secondVar = null;
                    if (input.IsSuccess)
                    {
                        secondVar = input.Result;
                        operation = operInButton;
                        BlockOperation.Text = secondVar + operation;
                        BlockAnswer.Text = secondVar;
                    }
                    else
                        ErrorMessage(input.ErrorMessage);
                }
                else
                {
                    operation = operInButton;
                    BlockOperation.Text = secondVar + operation;
                }
            }

            downString.Clear();
        }

        private void Button_equally(object sender, EventArgs e)
        {
            if (firstVar == null)
                firstVar = "0";
            else
            {
                firstVar = DelExtraSymb(firstVar);
                BlockAnswer.Text = firstVar;
            }

            if (operation == null)
            {
                secondVar = firstVar;
                BlockOperation.Text = firstVar + '=';
            }
            else
            {
                if (secondVar == null)
                    secondVar = firstVar;

                OutResult input = ExeсutOperation();

                if (input.IsSuccess)
                {
                    BlockOperation.Text = secondVar + operation + firstVar + '=';
                    secondVar = input.Result;
                    BlockAnswer.Text = secondVar;
                }
                else
                    ErrorMessage(input.ErrorMessage);
            }

            downString.Clear();
        }
    }
}
