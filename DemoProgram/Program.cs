using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace DemoProgram
{       /*Variant 2
           Define a class Person which contains:
           - Fields TaxNumber, firstname, lastname, birthdate
           - Constructor with parameters
           - PersonInput() and output() methods for input/output from/to console
           - Getters and setters
           - Method GetAge() calculating the person’s age in full years
           - Overridden ToString() method 
           Define a descendant class Student that has:
           - Additional field YearOfEntry 
           - Constructor with parameters 
           - A/dditional getter and setter
           - Overridden input() and output() methods
            Create a collection of peopleList and add some different people and students to it.              
           - Output the data about people elder than 18 years
           - Sort the data by firstname and lastname
           - Output the collection to a file
           - Implement exception handling
           - Serialize the collection to XML file
           - Deserialize it back
           - Write unit tests */
    public class Program
    {
        static void Main(string[] args)
        {
            // Create a collection of peopleList and add some different peopleList and students to it.

            List<Person> people = new List<Person>
            {
                new Person("Allison", "Ware", "23.06.1995", 2882341673),
                new Person("Andrew", "Denysov", "07.07.2004", 2793458756),
                new Person("Alex", "Miracle", "09.01.1998", 2192765308),
                new Student("Maksym", "Kot", "22.11.2000", 219223465, 2020),
                new Student("Oleh", "Mavdryk", "16.08.2003", 218242567, 2020),
                new Student("Natalia", "Petriv", "10.11.1999", 2347651234, 2017),
                new Student("Oleh", "Alishev", "01.03.2000", 2107667231, 2017)
            };

            // Output the data about people elder than 18 years

            foreach (Person p in people)
            {
                if (p.GetAge() > 18)
                    Console.WriteLine(p.ToString());
            }
            Console.WriteLine();

            // Sort the data by lastname and firstname  

            var sortedPeople = people.OrderBy(p => p.FirstName).ThenBy(p => p.LastName);
            foreach (Person p in sortedPeople)
            Console.WriteLine(p);
            Console.WriteLine();


            //Output the collection to a file
            string txtFilePath = @"D:\SET\DEMO2\DemoProgram\DemoProgram\list.txt";
            WriteCollectionToFile(txtFilePath, people);

            //Serialize the collection to XML file
            XmlSerializer formatter = new XmlSerializer(typeof(List<Person>));

            MyCollectionSerializer collectionSerializer = new MyCollectionSerializer();
            string xmlFilePath = @"D:\SET\DEMO2\DemoProgram\DemoProgram\peopleList.xml";
            collectionSerializer.SerializeCollectionToXML(xmlFilePath, formatter, people);

            //Deserialize it back             
            collectionSerializer.DeserializeCollectionFromXML(xmlFilePath, formatter);
            Console.ReadKey();
        }
        public static void WriteCollectionToFile(string filePath, List<Person>p)
        {
            try
            {
                using StreamWriter sw = new StreamWriter(filePath);
                foreach (Person x in p)
                {
                    sw.WriteLine(x);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}, the collection wasn't written to file");
            }
        }
    }
}


