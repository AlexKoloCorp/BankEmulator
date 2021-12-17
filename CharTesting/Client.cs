using System;

namespace BankEmulator
{
    class TestClass
    {
        public string Name { get; set; }
        public TestClass()
        {

        }
        public TestClass(string name)
        {
            Name = name;
        }
    }
    class Client : Person, IAccauntActivity, ICloneable
    {        
        private double _accBalance;
        public TestClass testClass = new TestClass { Name = "someNameForTestClass"};
        public double AccBalance
        {
            get { return _accBalance; }
        }
        public Client() { }
        public Client(string name, string pasportId, string phoneNumber, double accBalance) :
            base(name, pasportId, phoneNumber)
        {            
            _accBalance = accBalance;
        }
        public void Put(double amount)
        {
            _accBalance += amount;
            base._accauntActivity?.Invoke(this, new AccauntEventArgs($"Your account has been replenished: [{amount}]" +
                $"\nYour current balance: [{_accBalance}]", _accBalance));            
        }  
        public void Withdraw(double amount)
        {
            if (amount > _accBalance)
            {
                base._accauntActivity?.Invoke(this, new AccauntEventArgs($"You don't have enough withdrawal funds: [{amount}]" +
                    $"\nYour current balance: [{_accBalance}]", _accBalance));               
            }
            else
            {
                _accBalance -= amount;
                base._accauntActivity?.Invoke(this, new AccauntEventArgs($"Your account has been charged: [{amount}]" +
                    $"\nYor current balance: [{_accBalance}]", _accBalance));                
            }
        }

        public void Transfer(Client person, double amount)
        {
            if (amount>this._accBalance)
            {
                base._accauntActivity?.Invoke(this, new AccauntEventArgs($"You don't have enough funds for transfer: [{amount}]" +
                    $"\nYour current balance: [{_accBalance}]", _accBalance));                
            }
            else
            {
                this._accBalance -= amount;
                person._accBalance += amount;
                base._accauntActivity?.Invoke(this, new AccauntEventArgs($"The transfer of funds: [{amount}], to {person.Name} accaunt was completed successfully" +
                    $"\nYour current balance: [{_accBalance}]", _accBalance));                
            }            
        }

        public void TopUpYourPhone(double amount)
        {
            Withdraw(amount);
            base._accauntActivity?.Invoke(this, new AccauntEventArgs($"The account of this number:  [{PhoneNumber}] was topped up: [{amount}]" +
                $"\nYour current balance: [{_accBalance}]", _accBalance));           
        }
        public override void DisplayInfo()
        {            
            Console.WriteLine("|~~~~~~~~~|\nPerson name: {0};\nPerson pasportId: {1};\nPerson phone number: {2};\nPerson balance: {3};\n|~~~~~~~~~|",
            Name, PasportId, PhoneNumber, AccBalance);
        }

        public object Clone()
        {
            TestClass testClassCopy = new TestClass{ Name = this.testClass.Name };
            return new Client
            {
                Name = this.Name,
                PasportId = this.PasportId,
                PhoneNumber = this.PhoneNumber,
                _accBalance = this.AccBalance,
                testClass = testClassCopy
            };
        }
    }
}
