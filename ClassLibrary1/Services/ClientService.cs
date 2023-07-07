using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Program.Library.Models;

namespace Program.Library.Services
{
    public class ClientService
    {
        private static ClientService? instance;
        private static object _lock = new object();
        public static ClientService Current
        {
            get
            {
                lock (_lock)
                {
                    if(instance == null)
                    {
                        instance = new ClientService();
                    }
                }
                return instance; 
            }
        }
        private List<Client> clientList;
        private ClientService()
        {
            clientList = new List<Client>
            {
            };
        }

        public List<Client> ClientList
        {
            get
            {
                return clientList;
            }
        }

        private int idIncrement;
        public int IdIncrement
        {
            get
            {
                if(clientList.Count == 0) { idIncrement++; }
                else
                {
                    for (int i = 0; i < clientList.Count; i++)
                    {
                        idIncrement = clientList[i].Id;
                        if (clientList[i].Id > idIncrement)
                        {
                            idIncrement = clientList[i].Id;
                        }
                    }
                    idIncrement++;
                }
                return idIncrement;
            }
        }

        public List<Client> Search(string query)
        {
            return ClientList.Where(s => s.Name.ToUpper().Contains(query.ToUpper())).ToList();
        }

        public Client? Get(int id)
        {
            return clientList.FirstOrDefault(e => e.Id == id);
        }

        public void Add(Client? client)
        {
            if(client != null)
            {
                clientList.Add(client);
            }
        }

        public void Delete(int id)
        {
            var clientToRemove = Get(id);
            if(clientToRemove != null)
            {
                clientList.Remove(clientToRemove);
            }
        }

        public Client? GetById(int id)
        {
            return ClientList.FirstOrDefault(p => p.Id == id);
        }

        public void Delete(Client s)
        {
            Delete(s.Id);
        }

        public void Read()
        {
            clientList.ForEach(Console.WriteLine);
        }
    }
}
