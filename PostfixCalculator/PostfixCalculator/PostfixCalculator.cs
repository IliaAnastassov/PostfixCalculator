using System;
using System.Collections.Generic;
using System.Linq;

namespace PostfixCalculator
{
    /// <summary>
    /// A simple calculator using postfix notation.
    /// </summary>
    public class PostfixCalculator
    {
        private const string ADDITION = "+";
        private const string SUBTRACTION = "-";
        private const string MULTIPLICATION = "*";
        private const string DIVISION = "/";

        private const string WHITESPACE = " ";

        private Stack<int> _values;
        private Dictionary<string, Func<int, int, int>> _operations;

        /// <summary>
        /// Creates a new instance of the PostfixCalculator.
        /// </summary>
        public PostfixCalculator()
        {
            _values = new Stack<int>();
            _operations = new Dictionary<string, Func<int, int, int>>();
            _operations.Add(ADDITION, Sum);
            _operations.Add(SUBTRACTION, Subtract);
            _operations.Add(MULTIPLICATION, Multiply);
            _operations.Add(DIVISION, Divide);
        }

        /// <summary>
        /// Calculates the given expression.
        /// </summary>
        /// <param name="expression">The expression to calculate.</param>
        /// <returns>The result of the expression.</returns>
        public int Calculate(string expression)
        {
            var tokens = ExtractTokens(expression);

            foreach (var token in tokens)
            {
                if (int.TryParse(token, out int number))
                {
                    _values.Push(number);
                }
                else
                {
                    PerformOperation(token);
                }
            }

            var finalResult = _values.Pop();
            return finalResult;
        }

        private IEnumerable<string> ExtractTokens(string expression)
        {
            return expression.Split(WHITESPACE, StringSplitOptions.RemoveEmptyEntries);
        }

        private void PerformOperation(string token)
        {
            if (!_operations.Keys.Contains(token))
            {
                throw new ArgumentException(string.Format(Messages.INVALID_TOKEN, token));
            }

            var rightOperand = _values.Pop();
            var leftOperand = _values.Pop();
            var result = _operations[token].Invoke(rightOperand, leftOperand);
            _values.Push(result);
        }

        private int Sum(int leftOperand, int rightOperand)
        {
            return leftOperand + rightOperand;
        }

        private int Subtract(int leftOperand, int rightOperand)
        {
            return leftOperand - rightOperand;
        }

        private int Multiply(int leftOperand, int rightOperand)
        {
            return leftOperand * rightOperand;
        }

        private int Divide(int leftOperand, int rightOperand)
        {
            return leftOperand / rightOperand;
        }
    }
}
