using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateString
{
    class ArithmaticOperation
    {
        private List<String> OperationOrder = new List<string>();
        public ArithmaticOperation()
        {
            OperationOrder.Add("/");
            OperationOrder.Add("*");
            OperationOrder.Add("-");
            OperationOrder.Add("+");
        }
        public decimal ProcessOperation(string operation)
        {

            ArrayList arr = new ArrayList();
            string s = "";
            for (int i = 0; i < operation.Length; i++)
            {
                string currentCharacter = operation.Substring(i, 1);
                if (OperationOrder.IndexOf(currentCharacter) > -1)
                {
                    if (s != "")
                    {
                        arr.Add(s);
                    }
                    arr.Add(currentCharacter);
                    s = "";
                }
                else
                {
                    s += currentCharacter;
                }
            }
            arr.Add(s);
            s = "";
            foreach (string op in OperationOrder)
            {
                while (arr.IndexOf(op) > -1)
                {
                    int operatorIndex = arr.IndexOf(op);
                    decimal digitBeforeOperator = Convert.ToDecimal(arr[operatorIndex - 1]);
                    decimal digitAfterOperator = 0;
                    if (arr[operatorIndex + 1].ToString() == "-")
                    {
                        arr.RemoveAt(operatorIndex + 1);
                        digitAfterOperator = Convert.ToDecimal(arr[operatorIndex + 1]) * -1;
                    }
                    else
                    {
                        digitAfterOperator = Convert.ToDecimal(arr[operatorIndex + 1]);
                    }
                    arr[operatorIndex] = CalculateByOperator(digitBeforeOperator, digitAfterOperator, op);
                    arr.RemoveAt(operatorIndex - 1);
                    arr.RemoveAt(operatorIndex);
                }
            }
            return Convert.ToDecimal(arr[0]);
        }
        private decimal CalculateByOperator(decimal number1, decimal number2, string op)
        {
            if (op == "/")
            {
                return number1 / number2;
            }
            else if (op == "*")
            {
                return number1 * number2;
            }
            else if (op == "-")
            {
                return number1 - number2;
            }
            else if (op == "+")
            {
                return number1 + number2;
            }
            else
            {
                return 0;
            }
        }
    }
}
