using System;
using System.Collections.Generic;
using System.Text;

namespace PostfixCalculator
{
    public class PostfixCalculator
    {
        private const string ADDITION = "+";
        private const string SUBTRACTION = "-";
        private const string MULTIPLICATION = "*";
        private const string DIVISION = "/";
        private const string MODULUS = "%";

        private Stack<int> values;

        public PostfixCalculator()
        {
            values = new Stack<int>();
        }

        public int Calculate(IEnumerable<string> tokens)
        {
            foreach (var token in tokens)
            {
                if (int.TryParse(token, out int number))
                {
                    values.Push(number);
                }
                else
                {
                    var rightOperand = values.Pop();
                    var leftOperand = values.Pop();

                    if (token == ADDITION)
                    {
                        var result = leftOperand + rightOperand;
                        values.Push(result);
                    }
                    else if (token == SUBTRACTION)
                    {
                        var operationResult = leftOperand - rightOperand;
                        values.Push(operationResult);
                    }
                    else if (token == MULTIPLICATION)
                    {
                        var result = leftOperand * rightOperand;
                        values.Push(result);
                    }
                    else if (token == DIVISION)
                    {
                        var result = leftOperand / rightOperand;
                        values.Push(result);
                    }
                    else if (token == MODULUS)
                    {
                        var result = leftOperand % rightOperand;
                        values.Push(result);
                    }
                }
            }

            var finalResult = values.Pop();
            return finalResult;
        }
    }
}
