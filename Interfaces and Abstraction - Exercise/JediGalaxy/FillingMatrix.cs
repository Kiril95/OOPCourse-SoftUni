namespace P03_JediGalaxy
{
    public class FillingMatrix
    {
        public static void FillMatrix(int[,] matrix)
        {
            int counter = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = counter++;
                }
            }
        }
    }
}