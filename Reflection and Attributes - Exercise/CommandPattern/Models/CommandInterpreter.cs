using System;
using System.Linq;
using System.Reflection;
using CommandPattern.Contracts;

namespace CommandPattern.Models
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] input = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string commandName = (input[0] + "Command").ToLower();

            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(n => n.Name.ToLower() == commandName); 
            ICommand instance = (ICommand)Activator.CreateInstance(type ?? throw new ArgumentException("Invalid command type!"));
            string result = instance?.Execute(input.Skip(1).ToArray());
            return result;
        }
    }
}