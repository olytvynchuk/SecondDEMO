using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace DemoProgram
{    /*Define a class Person which contains:
-	Fields TaxNumber, firstname, lastname, birthdate
-	Constructor with parameters
-	PersonInput() and output() methods for input/output from/to console
-	Getters and setters
-	Method GetAge() calculating the person’s age in full years
-	Overridden ToString() method */

    [XmlInclude(typeof(Student))]
    [Serializable]
    public class Person
    {
        private string firstName;
        private string lastName;
        private DateTime birthDate;
        private uint taxNumber;
        public static readonly string dateFormat = "dd.mm.yyyy";
        public static readonly CultureInfo dateProvider = CultureInfo.CurrentCulture;
        public Person() { }
        public Person(string firstName, string lastName, string birthDate, uint taxNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthDate = DateTime.ParseExact(birthDate, dateFormat, dateProvider);
            this.taxNumber = taxNumber;
        }
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public DateTime BirthDate { get { return birthDate; } set { birthDate = value; } }
        public uint TaxNumber { get { return taxNumber; } set { taxNumber = value; } }

        public int GetAge()
        {
            DateTime now = DateTime.Now;
            int age = now.Year - birthDate.Year;
            if (birthDate > now.AddYears(-age))
                age--;
            return age;
        }
        public static bool IsAlphabets(string inputString)
        {
            Regex r = new Regex("^[a-zA-Z ]+$");
            return r.IsMatch(inputString);
        }
        public virtual void Input()
        {
            Console.WriteLine("Enter your first name");
            firstName = InputStringWithHandleExeption().ToUpper();
            Console.WriteLine("Enter your last name");
            lastName = InputStringWithHandleExeption().ToUpper();
            Console.WriteLine("Enter your tax number, please:");
            taxNumber = InputUintWithHandleExeption();
            Console.WriteLine("Enter your birth date");
            birthDate = InputDateOfBirthWithHandleException();

        }
        public string InputStringWithHandleExeption()
        {
            string inputString;
            while (true)
            {
                inputString = Console.ReadLine();
                if (IsAlphabets(inputString))
                {
                    return inputString;
                }
                else
                {
                    Console.WriteLine("Warning: Invalid input, this field should contain only letters!\n Try again!");
                }
            }
        }
        public uint InputUintWithHandleExeption()
        {
            uint inputUint;
            while (true)
            {
                try
                {
                    inputUint = uint.Parse(Console.ReadLine());
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Warning: Tax number should contain only integer number!\n Try again!\n Error: {ex.Message}.");
                    continue;
                }
                if (inputUint < 0)
                {
                    Console.WriteLine("Warning: Invalid Tax number should contain only positive integer number!\n Try again!");
                    continue;
                }
                return inputUint;
            }
        }
        public DateTime InputDateOfBirthWithHandleException()
        {
            DateTime dateOfBirth;
            while (true)
            {
                try
                {
                    dateOfBirth = DateTime.ParseExact(Console.ReadLine(), dateFormat, dateProvider);
                    return dateOfBirth;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Warning:Date of birth should be {dateFormat}!\n Try again!\n Error: {ex.Message}.");
                    continue;
                }
            }
        }
        public virtual string Output() => $"{firstName},{lastName}, {birthDate}, {taxNumber}";
        public override string ToString() => $"{firstName} {lastName}, {birthDate.ToString(dateFormat)}, {taxNumber}";
    }
}

