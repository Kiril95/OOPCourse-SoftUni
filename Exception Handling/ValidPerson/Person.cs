using System;

namespace ValidPerson
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName
        {
            get => firstName;
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new FormatException("First name cannot be null or empty!");
                }

                firstName = value;
            }
        }

        public string LastName
        {
            get => lastName;
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new FormatException("Last name cannot be null or empty!");
                }

                lastName = value;
            }
        }

        public int Age
        {
            get => age;
            protected set
            {
                if (value < 0 || value > 120)
                {
                    throw new ArgumentException("Person's age must be in the range [0...120]!");
                }

                age = value;
            }
        }

    }
}
