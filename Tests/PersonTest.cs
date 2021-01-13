using DemoProgram;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Tests
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void Test_GetAge()
        {
            Person p = new Student("Maksym", "Kot", "22.11.2000", 219223465, 2020);
            int expected = 20;
            Assert.AreEqual(expected, p.GetAge());
        }
        [TestMethod]
        public void Test_IsAlphbets()
        {
            bool expected = true;
            string firstName = "Olha";
            bool result = Person.IsAlphabets(firstName);
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Test_Is_Not_Alphabets()
        {
            bool expected = false;
            string firstName = "@Max2";
            bool result = Person.IsAlphabets(firstName);
            Assert.AreEqual(expected, result);

        }
        [TestMethod]
        public void Test_Person_FirstName()
        {
            string expected = "Alex";
            Person p = new Person("Alex", "Grahem", "20.01.2003", 2723944585);
            Assert.AreEqual(expected, p.FirstName);
        }
        [TestMethod]
        public void Test_Person_LastName()
        {
            string expected = "Corner";
            Person p = new Person("Michael", "Corner", "02.08.2000", 2713944565);
            Assert.AreEqual(expected, p.LastName);
        }
        [TestMethod]
        public void Test_Person_TaxNumber()
        {
            uint expected = 2713944565;
            Person p = new Person("Michael", "Corner", "02.08.2000", 2713944565);
            Assert.AreEqual(expected, p.TaxNumber);
        }
        [TestMethod]
        public void Test_Person_BirthDate()
        {
            string expected = "02.08.2000";
            Person p = new Person("Michael", "Corner", "02.08.2000", 2713944565);
            Assert.AreEqual(expected, p.BirthDate.ToString(Person.dateFormat));
        }
        [TestMethod]
        public void Test_Person_Invalid_BirthDate()
        {
            string expected = "fseggd";
            Person p = new Person("Michael", "Corner", "02.08.2000", 2713944565);
            Assert.AreNotEqual(expected, p.BirthDate.ToString(Person.dateFormat));
        }
        [TestMethod]
        public void Test_SerializeCollectionToXML()

        {
            List<Person> people = new List<Person>();

            people.Add(new Person("Allison", "Ware", "23.06.1995", 2882341673));
            people.Add(new Person("Andrew", "Denysov", "07.07.2004", 2793458756));
            people.Add(new Person("Alex", "Miracle", "09.01.1998", 2192765308));
            people.Add(new Student("Maksym", "Kot", "22.11.2000", 219223465, 2020));
            people.Add(new Student("Oleh", "Mavdryk", "16.08.2003", 218242567, 2020));
            people.Add(new Student("Natalia", "Petriv", "10.11.1999", 2347651234, 2017));
            people.Add(new Student("Oleh", "Alishev", "01.03.2000", 2107667231, 2017));
            

            string personsXmlPath = @"D:\SET\DEMO2\DemoProgram\DemoProgram\peopleList.xml";
            string expected = File.ReadAllLines(personsXmlPath).ToString();

            XmlSerializer formatter = new XmlSerializer(typeof(List<Person>));
            MyCollectionSerializer collectionSerializer = new MyCollectionSerializer();
            string xmlTestFilePath = @"D:\SET\DEMO2\DemoProgram\DemoProgram\peopleListTest.xml";
            collectionSerializer.SerializeCollectionToXML(xmlTestFilePath, formatter, people);
            string actual = File.ReadAllLines(xmlTestFilePath).ToString();
            Assert.IsTrue(expected == actual);


        }

    }
}
