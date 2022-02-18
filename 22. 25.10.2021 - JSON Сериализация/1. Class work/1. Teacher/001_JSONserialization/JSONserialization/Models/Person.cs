using System;
using System.Runtime.Serialization;

namespace JSONserialization.Models
{
    [Serializable]  // для JSON не используетя
    [DataContract]  // для JSON
    public class Person
    {
        [DataMember]  // для JSON
        public string FirstName { get; set; }
        
        [DataMember]
        public string LastName  { get; set; }
        
        [DataMember] // для записи private поля :)
        public int    Age       { get; set; }

        // стандартный конструктор без параметров
        public Person() { }

        public Person(string lastName, string firstName, int age) {
            LastName = lastName;
            FirstName = firstName;
            Age = age;
        } // Person

        public override string ToString() => $"{FirstName, -10} {LastName, -10} Возраст, лет: {Age}";
    } // class Person
}
