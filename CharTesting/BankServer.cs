using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankEmulator
{
    class ClientEnumerator:IEnumerator<Client>
    {
        private Client[] clients;
        private int position = -1;
        public ClientEnumerator(Client[] clients)
        {
            this.clients = clients;
        }
        public Client Current
        {
            get
            {
                if (position == -1 || position >= clients.Length)
                {
                    throw new InvalidOperationException();
                }
                return clients[position];
            }
        }
        object IEnumerator.Current => throw new NotImplementedException();


        public void Dispose() { }

        public bool MoveNext()
        {
            if (position < clients.Length -1)
            {
                position++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            position = -1;
        }
    }
    class BankServer
    {
        private Client[] listOfClients = new Client[3];
        public BankServer()
        {
            listOfClients[0] = new Client("Sarah Syfer", "124456", "+380974591687", 1000);
            listOfClients[1] = new Client("Jack Longbottom", "123456", "+380994567687", 1500);
            listOfClients[2] = new Client("Tery Kittel", "923456", "+380504568187", 700);
        }        
        public IEnumerator<Client> GetEnumerator()
        {
            return new ClientEnumerator(listOfClients);
        }
    }
}
