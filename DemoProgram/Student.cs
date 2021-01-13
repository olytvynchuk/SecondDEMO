using System;

namespace DemoProgram
{   /*Define a descendant class Student that has:
-	Additional field YearOfEntry 
-	Constructor with parameters 
-	Additional getter and setter
-	Overridden input() and output() methods*/
                                                                                                                
    [Serializable]
    public class Student : Person
    {
        private int yearOfEntry;
        public Student()
        {

        }
        public Student(string firstName, string lastName, string birthDate, uint taxNumber, int yearOfEntry)
            : base(firstName, lastName, birthDate, taxNumber)
        {
            this.yearOfEntry = yearOfEntry;

        }
        public int YearOfEntry { get { return yearOfEntry; } set { yearOfEntry = value; } }

        public override void Input()
        {
            base.Input();
            Console.WriteLine("Enter your year of entry");
            yearOfEntry = InputIntWithHandleExeption();
        }

        public int InputIntWithHandleExeption()
        {
            int inputInt;

            while (true)
            {
                try
                {
                    inputInt = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine($" Warning: Year of entry should contain only a four-digit integer number ! Error: {e.Message}.\n Try again! ");
                    continue;
                }
                if (inputInt < 0)
                {
                    Console.WriteLine("Warning: Year of entry should be only positive integer number! \n Try again!");
                    continue;
                }
                return inputInt;
            }
        }
        public override string Output()
        {
            return $"{base.Output()} {yearOfEntry}";
            //Console.WriteLine($"year of entry is {yearOfEntry}");
        }
        public override string ToString() => $"{base.ToString()}, student, year of entry {yearOfEntry}";
    }
}
