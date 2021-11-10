namespace CommandPattern.Contracts
{
    public interface ICommandInterpreter
    {
        string Read(string args);
    }
}
