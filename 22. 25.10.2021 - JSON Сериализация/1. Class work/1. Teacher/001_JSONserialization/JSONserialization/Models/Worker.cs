using System;
using System.Runtime.Serialization;

namespace JSONserialization.Models
{
    [Serializable]
    [DataContract]
    public class Worker
    {
        [DataMember]
        public string FirstName { get; set; }
        
        [DataMember]
        public string LastName { get; set; }
        
        [DataMember]
        public int Age { get; set; }

        [DataMember]  
        public Company Company { get; set; }

        // стандартный конструктор без параметров
        public Worker() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lastName"></param>
        /// <param name="firstName"></param>
        /// <param name="age"></param>
        /// <param name="company"></param>
        public Worker(string lastName, string firstName, int age, Company company) {
            LastName = lastName;
            FirstName = firstName;
            Age = age;
            Company = company;
        } // Worker

        public override string ToString() => $"{FirstName, -10} {LastName, -10} Возраст, лет: {Age, 3}. {Company}";
    } // class Worker
}
