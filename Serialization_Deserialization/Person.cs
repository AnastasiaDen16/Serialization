using System.Runtime.Serialization;

namespace Serialization_Deserialization
{
    [DataContract]
    public class Person
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public string Adress { get; set; }
    }
}
