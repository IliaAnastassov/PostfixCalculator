using System;
using static System.Console;

namespace PostfixCalculator
{
    public class Program
    {
        static void Main()
        {
            WriteLine(Messages.WELCOME);
            var expression = ReadLine();

            try
            {
                var calculator = new PostfixCalculator();
                var result = calculator.Calculate(expression);
                WriteLine(result);
            }
            catch (ArgumentException argEx)
            {
                WriteLine(argEx.Message);
            }
            catch (Exception)
            {
                WriteLine(Messages.ERROR);
            }
        }
    }
}
