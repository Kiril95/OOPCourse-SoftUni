using System;

namespace ValidPerson
{
    class Program
    {
        static void Main(string[] args)
        {
            Person correctPerson = new Person("Boiko", "BorisoFF", 69);

            try
            {
                Person firstNameError = new Person(string.Empty, "Petkov", 33);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            
            try
            {
                Person lastNameError = new Person("Korneliya", string.Empty, 22);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }

            try
            {
                Person negativeAgeError = new Person("Slavi", "TrifonoFF", -133);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }

            try
            {
                Person bigAgeError = new Person("Boko", "ThePumpkin", 666);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
