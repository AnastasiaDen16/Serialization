using Nancy.Json;
using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Serialization_Deserialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Serialization_DCJS();
            Serialization_JSS();
        }
        public static void Serialization_DCJS()
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Person));
            MemoryStream stream = new MemoryStream();
            serializer.WriteObject(stream, InitPerson());
        }
        public static void Serialization_JSS()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(InitPerson());
            Console.WriteLine(json);
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
