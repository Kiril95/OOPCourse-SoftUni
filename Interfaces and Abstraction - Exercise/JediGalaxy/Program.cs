using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int x = dimensions[0];
            int y = dimensions[1];
            int[,] matrix = new int[x, y];

            FillingMatrix.FillMatrix(matrix);

            string command = Console.ReadLine();
            long sumOfStars = 0;

            while (command != "Let the Force be with you")
            {
                int[] ivoS = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int[] evil = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int xE = evil[0];
                int yE = evil[1];

                DarkForceAction.DestroyStars(ref matrix, xE, yE);

                int xI = ivoS[0];
                int yI = ivoS[1];

                IvoAction.CollectStars(ref matrix, xI, yI, ref sumOfStars);

                command = Console.ReadLine();
            }

            Console.WriteLine(sumOfStars);
        }
    }
}
