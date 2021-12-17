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
            client.DisplayInfo();
            client.testClass.Name = "Client class name";            
            Console.WriteLine($"Another class inside Client class = {client.testClass.Name}");
            Client client1 = new Client("Ada Nerin", "123457", "+380998767612", 1200);
            client1.AccauntActivityEvent += GetMessage;
            //BankServer bankServer = new BankServer();
            //foreach (Client item in bankServer)
            //{
            //    item.DisplayInfo();
            //}            
            Console.WriteLine("******************************");
            Client client2 = (Client)client.Clone();
            client2.AccauntActivityEvent += GetMessage;
            client2.Name = "Paul Atreydes";
            client2.PasportId = "654321";
            client2.PhoneNumber = "+380000000000";
            client2.DisplayInfo();
            client2.Withdraw(599);
            client2.testClass.Name = "Client2 class name";            
            Console.WriteLine($"Another class inside Client class = {client2.testClass.Name}"); 
            client.DisplayInfo();
            Console.WriteLine("__________________________________________________________________________");
            Client[] clients = new Client[] { client, client1, client2 };
            Console.WriteLine("~~Befor sorting~~");
            foreach (var item in clients)
            {
                item.DisplayInfo();
            }
            Console.WriteLine("~~After sorting~~");
            Array.Sort(clients, new ClientsComparer());
            foreach (var item in clients)
            {
                item.DisplayInfo();
            }

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
                    client.Put(OperationWithMoney());
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
                    client.Withdraw(OperationWithMoney());
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
                    client.Transfer(client1, OperationWithMoney());
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
                    client1.TopUpYourPhone(OperationWithMoney());
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
        public static int OperationWithMoney()
        {
            int sumOfOperation = int.Parse(Console.ReadLine());
            return sumOfOperation;
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
