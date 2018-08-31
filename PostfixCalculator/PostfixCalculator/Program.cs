using System;

namespace PostfixCalculator
{
    class Program
    {
        static void Main(string[] args)
        {


            foreach (var token in args)
            {
                int number;

                if (int.TryParse(token, out number))
                {

                }
            }
        }
    }
}
