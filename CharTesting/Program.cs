using System;
using System.Collections;
using System.Collections.Generic;

namespace BankEmulator
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Client client = new Client("Jack Longbottom", "123456", "+380994567687", 1000);
            client.AccauntActivityEvent += GetMessage;
            client.Put(400);
            client.Withdraw(700);
            Client client1 = new Client("Ada Nerin", "123457", "+380998767612", 1200);
            client1.AccauntActivityEvent += GetMessage;
            client.Transfer(client1, 500);
            Console.WriteLine("{0} curren balance: {1}", client1.Name, client1.AccBalance);
            client1.PhoneNumber = "+380983458763";
            client1.TopUpYourPhone(85);
            client1.DisplayInfo();
        }
        public static void GetMessage(object o, AccauntEventArgs e)
        {
            Console.WriteLine($"object: [{o.ToString()}]; message: [{e.Message}]"); 
        }
    }
}
