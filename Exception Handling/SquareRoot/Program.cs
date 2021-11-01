using System;

namespace SquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());

                if (number < 0)
                {
                    throw new ArithmeticException("Invalid number!");
                }
                double result = Math.Sqrt(number);
                Console.WriteLine(result);
            }
            catch (ArithmeticException ae)
            {
                Console.WriteLine(ae.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye");
            }

        }
    }
}
