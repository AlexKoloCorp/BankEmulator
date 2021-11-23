using System;

namespace BankEmulator
{
    class Client : Person, IAccauntActivity
    {        
        private double _accBalance;

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
            Console.WriteLine("Person name: {0};\nPerson pasportId: {1};\nPerson phone number: {2};\nPerson balance: {3};",
            Name, PasportId, PhoneNumber, AccBalance);
        }
    }
}
