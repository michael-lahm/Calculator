﻿
namespace Calculator
{
    internal class EditString
    {
        private string? input;
        public string? Input
        {
            get
            {
                if (sign)
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
        }

        internal void AddNumber(char symb)
        {
            input ??= "0";
            if (input.Length < 20)
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
            input ??= "0";
            if (comma != true)
            {
                input += ',';
                comma = true;
            }
        }

        internal void InvertSign()
        {
            if (input?.Length > 1 || input?[0] != '0')
            {
                if (sign)
                    sign = false;
                else
                    sign = true;
            }
        }

        internal void DeletSymb()
        {
            if(input != null)
            {
                if (input.Length == 1)
                {
                    comma = false;
                    sign = false;
                    input = "0";
                }
                else
                {
                    if (input[^1] == ',')
                        comma = false;
                    input = input.Remove(input.Length - 1);
                }
            }
        }

        internal void Clear()
        {
            comma = false;
            sign = false;
            input = null;
        }
    }
}
