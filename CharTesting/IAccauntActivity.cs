using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
