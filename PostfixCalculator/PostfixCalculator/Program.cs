using System;
using static System.Console;

namespace PostfixCalculator
{
    public class Program
    {
        static void Main()
        {
            WriteLine("Enter the expression to calculate in postfix notation:");
            var userInput = ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            try
            {
                var calculator = new PostfixCalculator();
                var result = calculator.Calculate(userInput);
                WriteLine(result);
            }
            catch (ArgumentException argEx)
            {
                WriteLine(argEx.Message);
            }
            catch (Exception)
            {
                WriteLine("Something went wrong. Please verify the expression and try again.");
            }
        }
    }
}
