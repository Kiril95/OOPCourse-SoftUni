namespace P03_JediGalaxy
{
    public class Validator
    {
        public static bool Validate(int[,] matrix, int row, int col)
        {
            return (row >= 0 && row < matrix.GetLength(0))
                   && (col >= 0 && col < matrix.GetLength(1));
        }
    }
}