using DemoProgram;
using System.Collections.Generic;
using System.IO;
using Xunit;


namespace XUnitTestDemoProgram
{
    public class PeopleTest
    {
        [Fact]
        public void Test_GetAge()
        {
            Person p = new Student("Maksym", "Kot", "22.11.2000", 219223465, 2020);
            int expected = 20;
            Assert.Equal(expected, p.GetAge());
        }
        [Fact]
        public void Test_IsAlphbets()
        {
            bool expected = true;
            string firstName = "Olha";
            bool result = Person.IsAlphabets(firstName);
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Test_Is_Not_Alphabets()
        {
            bool expected = false;
            string firstName = "@Max2";
            bool result = Person.IsAlphabets(firstName);
            Assert.Equal(expected, result);

        }
        [Fact]
        
        public static void Test_WriteCollectionToFile()
        {
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

            string txtPath = @"D:\SET\DEMO2\DemoProgram\DemoProgram\list.txt";
            string expected = File.ReadAllLines(txtPath).ToString();

            string txtTestFilePath = @"D:\SET\DEMO2\DemoProgram\DemoProgram\listTest.txt";
            {
                using StreamWriter sw = new StreamWriter(txtTestFilePath);
                foreach (Person x in people)
                {
                    sw.WriteLine(x);
                }
            }
            string actual = File.ReadAllLines(txtTestFilePath).ToString();
                                   
            Assert.Equal(expected,actual);


        }
    }
}
