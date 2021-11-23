using System;

namespace BankEmulator
{
    interface IAccauntActivity
    {
        void Put(double amount);
        void Withdraw(double amount);
        void Transfer(Client person, double amount);
        void TopUpYourPhone(double amount);
    }
}
