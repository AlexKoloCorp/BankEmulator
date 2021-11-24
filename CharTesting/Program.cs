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
            Client client1 = new Client("Ada Nerin", "123457", "+380998767612", 1200);
            client1.AccauntActivityEvent += GetMessage;
            Start:
            Console.WriteLine("\t\t~~Bank menu~~\n" +
                "1. replenish your accaunt;" +
                "\n2. withdraw money from your accaunt;" +
                "\n3. transfer your money to another accaunt;" +
                "\n4. top up your phone number;");            
            int menuPicker = int.Parse(Console.ReadLine());
            switch (menuPicker)
            {
                case 1:
                    Console.Write("Enter sum for replenishment-> ");
                    int sunOfReplenish = int.Parse(Console.ReadLine());
                    client.Put(sunOfReplenish);
                    Console.WriteLine("Do you want to continue?\n" +
                         "y - yes\n" +
                         "n - no");
                    if (MenuFunc() == 'y')
                    {
                        Console.Clear();
                        goto Start;
                    }
                    break;
                case 2:
                    Console.Write("Enter sum for withdraw-> ");
                    int sumOfWithdraw = int.Parse(Console.ReadLine());
                    client.Withdraw(sumOfWithdraw);
                    Console.WriteLine("Do you want to continue?\n" +
                         "y - yes\n" +
                         "n - no");
                    if (MenuFunc() == 'y')
                    {
                        Console.Clear();
                        goto Start;
                    }
                    break;
                case 3:
                    Console.Write("Enter sum for transfer-> ");
                    int sumOfTransfer = int.Parse(Console.ReadLine());
                    client.Transfer(client1, sumOfTransfer);
                    Console.WriteLine("Do you want to continue?\n" +
                         "y - yes\n" +
                         "n - no");
                    if (MenuFunc() == 'y')
                    {
                        Console.Clear();
                        goto Start;
                    }
                    break;
                case 4:
                    client1.PhoneNumber = "+380983458763";
                    Console.Write("Enter sum for phone top up-> ");
                    int sumOfTopUp= int.Parse(Console.ReadLine());
                    client1.TopUpYourPhone(sumOfTopUp);
                    Console.WriteLine("Do you want to continue?\n" +
                         "y - yes\n" +
                         "n - no");
                    if (MenuFunc() == 'y')
                    {
                        Console.Clear();
                        goto Start;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid input data");
                    break;
            }           
            Console.WriteLine();
            //Console.WriteLine("{0} curren balance: {1}", client1.Name, client1.AccBalance);                       
            //client1.DisplayInfo();
        }
        public static char MenuFunc()
        {            
            char continuerChoosing = char.Parse(Console.ReadLine());
            return continuerChoosing;
        }
        public static void GetMessage(object o, AccauntEventArgs e)
        {
            Console.WriteLine($"object: [{o.ToString()}]; message: [{e.Message}]"); 
        }       
    }
}
