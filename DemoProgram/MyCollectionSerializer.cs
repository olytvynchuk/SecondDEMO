using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace DemoProgram
{
    public class MyCollectionSerializer
    {
        public void SerializeCollectionToXML(string filePath, XmlSerializer formatter, List <Person> list)
        {
            while (true)
            {
                try
                {
                    using FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
                    formatter.Serialize(fs, list);
                    Console.WriteLine("List was serialized\n");
                    break;
                }
                catch(Exception e)
                {
                    Console.WriteLine($"List wasn't serialized. Error: {e.Message} ");
                }
            }
        }
        
        public void DeserializeCollectionFromXML(string filePath, XmlSerializer formatter)
        {
            try
            {
                using FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
                List<Person> newpeople = (List<Person>)formatter.Deserialize(fs);
                foreach (Person p in newpeople)
                {
                    Console.WriteLine(p);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"List wasn't deserialized. Error: {e.Message}");
            }
        }
    }
}
