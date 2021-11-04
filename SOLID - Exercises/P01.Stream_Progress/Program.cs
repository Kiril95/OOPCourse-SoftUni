using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            StreamProgressInfo test1 = new StreamProgressInfo(new File("Deposits", 5, 15));
            StreamProgressInfo test2 = new StreamProgressInfo(new Music("The Weekend", "SomeAlbum", 15, 25));

            Console.WriteLine(test1.CalculateCurrentPercent());
            Console.WriteLine(test2.CalculateCurrentPercent());
        }
    }
}
