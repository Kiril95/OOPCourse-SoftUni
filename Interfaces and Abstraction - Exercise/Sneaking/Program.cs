using System;
using System.Linq;

namespace P06_Sneaking
{
    class Sneaking
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            char[][] room = new char[n][];

            int startRow = -1;
            int startCol = -1;
            bool isSamDead = false;
            FillMatrix(room, n, ref startRow, ref startCol);

            var orders = Console.ReadLine().ToCharArray();

            for (int i = 0; i < orders.Length; i++)
            {
                MoveEnemies(room, ref startRow, ref startCol, ref isSamDead);

                if (isSamDead)
                {
                    room[startRow][startCol] = 'X';
                    Console.WriteLine($"Sam died at {startRow}, {startCol}");
                    PrintMatrix(room);
                    return;
                }

                if (orders[i] == 'U')
                {
                    room[startRow][startCol] = '.';
                    room[startRow - 1][startCol] = 'S';
                    startRow -= 1;
                }
                else if (orders[i] == 'D')
                {
                    room[startRow][startCol] = '.';
                    room[startRow + 1][startCol] = 'S';
                    startRow += 1;
                }
                else if (orders[i] == 'L')
                {
                    room[startRow][startCol] = '.';
                    room[startRow][startCol - 1] = 'S';
                    startRow -= 1;
                }
                else if (orders[i] == 'R')
                {
                    room[startRow][startCol] = '.';
                    room[startRow][startCol + 1] = 'S';
                    startRow += 1;
                }

                CheckIfNikoladzeIsKilled(room, ref startRow, ref startCol);
            }
        }
        private static void CheckIfNikoladzeIsKilled(char[][] room, ref int startRow, ref int startCol)
        {
            if (room[startRow].Contains('N'))
            {
                int nikoCol = Array.IndexOf(room[startRow], 'N');
                room[startRow][nikoCol] = 'X';
                Console.WriteLine("Nikoladze killed!");
                PrintMatrix(room);
                Environment.Exit(0);
            }
        }

        private static void MoveEnemies(char[][] room, ref int samCurrentRow, ref int samCurrentCol, ref bool isSamDead)
        {
            for (int row = 0; row < room.Length; row++)
            {
                if (room[row].Contains('b'))
                {
                    int index = Array.IndexOf(room[row], 'b');
                    if (index == room[row].Length - 1)
                    {
                        room[row][index] = 'd';
                        if (samCurrentRow == row && samCurrentCol < index)
                        {
                            isSamDead = true;
                        }
                    }
                    else
                    {
                        room[row][index] = '.';
                        room[row][index + 1] = 'b';
                    }
                    if (samCurrentRow == row && samCurrentCol > index)
                    {
                        isSamDead = true;
                    }
                }
                else if (room[row].Contains('d'))
                {
                    int index = Array.IndexOf(room[row], 'd');

                    if (index == 0)
                    {
                        room[row][index] = 'b';
                        if (samCurrentRow == row && samCurrentCol > index)
                        {
                            isSamDead = true;
                        }
                    }
                    else
                    {
                        room[row][index] = '.';
                        room[row][index - 1] = 'd';
                    }

                    if (samCurrentRow == row && samCurrentCol < index)
                    {
                        isSamDead = true;
                    }
                }
            }
        }

        private static void FillMatrix(char[][] room, int size, ref int startRow, ref int startCol)
        {
            for (int row = 0; row < room.Length; row++)
            {
                char[] line = Console.ReadLine().ToCharArray();
                room[row] = line;
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'S')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }
        }
        private static void PrintMatrix(char[][] room)
        {
            foreach (var row in room)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}
