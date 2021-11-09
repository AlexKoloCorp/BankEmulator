using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankEmulator
{
    class Client : IAccauntActivity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        private double _accBalance;

        public double AccBalance
        {
            get { return _accBalance; }
        }
        public Client() { }
        public Client(string name, double accBalance)
        {
            Name = name;
            _accBalance = accBalance;
        }
        public void Put(double amount)
        {
            _accBalance += amount;
            Console.WriteLine("Your account has been replenished: {0}\nYour current balance: {1}",amount, _accBalance);
        }  
        public void Withdraw(double amount)
        {
            if (amount > _accBalance)
            {
                Console.WriteLine("You don't have enough withdrawal funds: {0}\nYour current balance: {1}", amount, _accBalance);
            }
            else
            {
                _accBalance -= amount;
                Console.WriteLine("Your account has been charged: {0}\nYor current balance: {1}", amount, _accBalance);
            }
        }

        public void Transfer(Client person, double amount)
        {
            if (amount>this._accBalance)
            {
                Console.WriteLine("You don't have enough funds for transfer: {0}\nYour current balance: {1}"
                    , amount, _accBalance);
            }
            else
            {
                this._accBalance -= amount;
                person._accBalance += amount;
                Console.WriteLine("The transfer of funds: {0}, to {1} accaunt was completed successfully\nYour current balance: {2}"
                    , amount, person.Name, AccBalance);
            }            
        }

        public void TopUpYourPhone(double amount)
        {
            Withdraw(amount);
            Console.WriteLine("The account of this number: {0} was topped up: {1}\nYour current balance: {2}",
                PhoneNumber, amount, AccBalance);
        }
    }
}
