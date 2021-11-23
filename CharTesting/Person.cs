using System;

namespace BankEmulator
{
    abstract class Person
    {
        public string Name { get; set; }
        public string PasportId { get; set; }
        public string PhoneNumber { get; set; }
        public delegate void AccauntActivityHandler(object o, AccauntEventArgs args);
        protected AccauntActivityHandler _accauntActivity;
        public event AccauntActivityHandler AccauntActivityEvent
        {
            add { _accauntActivity += value; Console.WriteLine($"method {value.Method.Name} was added to invocation list"); }
            remove { _accauntActivity -= value; Console.WriteLine($"method {value.Method.Name} has been removed from invocation list"); }
        }

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
