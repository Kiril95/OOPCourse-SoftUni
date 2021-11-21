namespace P03_JediGalaxy
{
    public class DarkForceAction
    {
        public static int[,] DestroyStars(ref int[,] matrix, int xE, int yE)
        {
            while (xE >= 0 && yE >= 0)
            {
                if (Validator.Validate(matrix, xE, yE))
                {
                    matrix[xE, yE] = 0;
                }

                xE--;
                yE--;
            }

            return matrix;
        }
    }
}