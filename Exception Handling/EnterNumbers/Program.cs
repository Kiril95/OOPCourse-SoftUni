using System;

namespace EnterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = 1;
            int end = 100;
            int number = 0;

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    number = ReadNumber(start, end, ref number);
                    Console.WriteLine($"The current number is {number}");
                }
                catch(ArithmeticException ae)
                {
                    Console.WriteLine(ae.Message);
                    i = 0;
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                    i = 0;
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                    i = 0;
                }
            }
        }
        static int ReadNumber(int start, int end, ref int number)
        {
            string input = Console.ReadLine();

            if (Int32.TryParse(input, out number))
            {
                if (number < 0)
                {
                    throw new ArithmeticException("The number cannot be negative!");
                }
                if (number < start || number > end)
                {
                    throw new ArgumentOutOfRangeException(nameof(number),$"The number is not in the range of {start}...{end}");
                }
            }
            else
            {
                throw new FormatException("The input is not a number! Try again.");
            }

            return number;
        }
    }
}