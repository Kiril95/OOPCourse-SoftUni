using System;

namespace CollectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            string[] operations = Console.ReadLine().Split();

            foreach (var item in operations)
            {
                Console.Write($"{addCollection.Add(item)} ");
            }
            Console.WriteLine();

            foreach (var item in operations)
            {
                Console.Write($"{addRemoveCollection.Add(item)} ");
            }
            Console.WriteLine();

            foreach (var item in operations)
            {
                Console.Write($"{myList.Add(item)} ");
            }
            Console.WriteLine();

            int times = int.Parse(Console.ReadLine());

            for (int i = 0; i < times; i++)
            {
                Console.Write($"{addRemoveCollection.Remove()} ");
            }
            Console.WriteLine();

            for (int i = 0; i < times; i++)
            {
                Console.Write($"{myList.Remove()} ");
            }
            Console.WriteLine();

        }
    }
}
