using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Elf elf = new Elf("Babatunde", 22);
            Console.WriteLine(elf);
            DarkKnight dark = new DarkKnight("Mutafchiiski", 88);
            Console.WriteLine(dark);
            Wizard wiz = new Wizard("Boiko", 66);
            Console.WriteLine(wiz);
        }
    }
}