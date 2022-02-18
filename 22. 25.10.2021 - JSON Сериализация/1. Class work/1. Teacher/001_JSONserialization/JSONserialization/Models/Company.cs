using System;
using System.Runtime.Serialization;

namespace JSONserialization.Models
{
    [Serializable]
    [DataContract]
    public class Company
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public double Amount { get; set; }


        // стандартный конструктор без параметров
        public Company():this("", 0) { }
        public Company(string name):this(name, 1000){
            Name = name;
        }        
        
        public Company(string name, double amount){
            Name = name;
            Amount = amount;
        }

        public override string ToString() =>
            $"{Name, -17} {Amount, 18:N2}$";
        
    } // class Company
}
