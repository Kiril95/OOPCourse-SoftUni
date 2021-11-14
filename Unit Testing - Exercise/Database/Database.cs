using System;

namespace Database
{
    public class Database
    {
        private const int AllowedCapacity = 16;
        private int[] data;
        private int count;

        public Database(params int[] data)
        {
            this.data = new int[AllowedCapacity];

            for (int i = 0; i < data.Length; i++)
            {
                this.Add(data[i]);
            }

            this.count = data.Length;
        }

        public int Count => count;
        public void Add(int element)
        {
            if (this.count >= AllowedCapacity)
            {
                throw new InvalidOperationException("Array's capacity must be exactly 16 integers!");
            }

            this.data[this.count] = element;
            this.count++;
        }
        public void Remove()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("The collection is empty!");
            }

            this.count--;
            this.data[this.count] = 0;
        }
        public int[] Fetch()
        {
            int[] coppyArray = new int[this.count];

            for (int i = 0; i < this.count; i++)
            {
                coppyArray[i] = this.data[i];
            }

            return coppyArray;
        }
    }
}
