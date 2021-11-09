using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankEmulator
{
    interface IAccauntActivity
    {
        void Put();
        void Withdraw();
        void Transfer();
        void TopUpYourPhone();
    }
}
