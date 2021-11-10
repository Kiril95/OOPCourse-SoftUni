using System;
using CommandPattern.Contracts;

namespace CommandPattern.Models
{
    public class ExitCommand : ICommand
    {
        public string Execute(string[] args)
        {
            Environment.Exit(0);
            return null;
        }
    }
}