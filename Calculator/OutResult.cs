using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class OutResult
    {
        internal string Result { get; private set; }
        internal bool IsSuccess { get; private set; }
        internal string ErrorMessage { get; private set; }

        public OutResult(string result, bool success)
        {
            IsSuccess = success;
            if (success)
            {
                Result = result;
                ErrorMessage = string.Empty;
            }
            else 
            { 
                Result = string.Empty;
                ErrorMessage = result;
            }
        }
    }
}
