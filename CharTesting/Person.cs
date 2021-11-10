using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankEmulator
{
    abstract class Person
    {
        public string Name { get; set; }
        public string PasportId { get; set; }
        public string PhoneNumber { get; set; }

        public Person() { }
        public Person(string name, string pasportId, string phoneNumber)
        {
            Name = name;
            PasportId = pasportId;
            PhoneNumber = phoneNumber;
        }
        public virtual void DisplayInfo() { Console.WriteLine("Person name: {0};\nPerson pasportId: {1};\nPerson phone number: {2}",
            Name, PasportId, PhoneNumber); }
    }
}
