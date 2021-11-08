namespace CodeTracker
{
    [Author("Kiro")]
    public class StartUp
    {
        [Author("Sekiro")]
        static void Main(string[] args)
        {
            Tracker tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}
