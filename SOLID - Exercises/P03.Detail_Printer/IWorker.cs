namespace P03.DetailPrinter
{
    public interface IWorker
    {
        string Name { get; }
        int Age { get; }
        string Country { get; }
        string Sector { get; }
    }
}