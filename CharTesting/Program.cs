using System;
using System.Collections;
using System.Collections.Generic;

namespace BankEmulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client("Jack Longbottom", 1000);
            client.Put(400);
            client.Withdraw(700);
            Client client1 = new Client("Ada Nerin", 1200);
            client.Transfer(client1, 500);
            Console.WriteLine("{0} curren balance: {1}", client1.Name, client1.AccBalance);
            client1.PhoneNumber = "+380983458763";
            client1.TopUpYourPhone(85);
        }
    }
}
