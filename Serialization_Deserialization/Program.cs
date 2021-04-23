using Nancy.Json;
using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Serialization_Deserialization
{
    class Program
    {
        static DataContractJsonSerializer serializerDC;
        static JavaScriptSerializer serializerJS; 
        static void Main(string[] args)
        {
            Console.WriteLine("DataContractJsonSerializer");
            Serialization_DCJS();
            Console.WriteLine("JavaScriptSerializer");
            Serialization_JSS();
        }

        public static void Serialization_DCJS()
        {
            serializerDC = new DataContractJsonSerializer(typeof(Person));
            MemoryStream stream = new MemoryStream();
            serializerDC.WriteObject(stream, InitPerson());
            Console.WriteLine("Deserialization");
            Deserialization_DCJS(stream);
        }

        public static void Serialization_JSS()
        {
            serializerJS = new JavaScriptSerializer();
            var json = serializerJS.Serialize(InitPerson());
            Console.WriteLine(json);
            Console.WriteLine("Deserialization");
            Deserialization_JSS(json);
        }

        public static void Deserialization_DCJS(MemoryStream stream)
        {
            stream.Position = 0;
            Person person = (Person)serializerDC.ReadObject(stream);
            Console.WriteLine($"Name: {person.Name} Surname {person.Surname} Adress {person.Adress}");
        }

        public static void Deserialization_JSS(string json)
        {
            Person person = serializerJS.Deserialize<Person>(json);
            Console.WriteLine($"Name: {person.Name} Surname {person.Surname} Adress {person.Adress}");
        }

        public static Person InitPerson()
        {
            Person person = new Person
            {
                Name = "Denisova",
                Surname = "Anastasia",
                Adress = "Gomel"
            };
            return person;
        }
    }
}
