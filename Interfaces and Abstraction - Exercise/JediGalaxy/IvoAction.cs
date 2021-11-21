namespace P03_JediGalaxy
{
    public class IvoAction
    {
        public static long CollectStars(ref int[,] matrix, int xI, int yI, ref long sumOfStars)
        {
            while (xI >= 0 && yI < matrix.GetLength(1))
            {
                if (Validator.Validate(matrix, xI, yI))
                {
                    sumOfStars += matrix[xI, yI];
                }

                yI++;
                xI--;
            }

            return sumOfStars;
        }
    }
}