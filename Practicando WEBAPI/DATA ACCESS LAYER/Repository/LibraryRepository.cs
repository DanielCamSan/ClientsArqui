using Practicando_WEBAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practicando_WEBAPI.Data.Repository
{                       
    public class LibraryRepository : ILibraryRepository
    {
        private List<ClientEntity> clients = new List<ClientEntity>(){
            new ClientEntity(){Id=1,Name="Daniel",Ci="5918928",BornDate=new DateTime(2000,03,15),Height=1.71m,Weight=64.5m,Classes=new List<string>{ "Spinning", "Calisthenics", "Machines"}},
            new ClientEntity(){Id=2,Name="Victor",Ci="3723130",BornDate=new DateTime(1995,05,17),Height=1.65m,Weight=106.4m,Classes=new List<string>{ "Spinning", "Calisthenics"}},
            new ClientEntity(){Id=3,Name="Kevin",Ci="3488088",BornDate=new DateTime(2001,12,26),Height=1.50m,Weight=75.1m,Classes=new List<string>{ "Machines"}},
            new ClientEntity(){Id=4,Name="Lucas",Ci="158695",BornDate=new DateTime(1995,01,6),Height=1.63m,Weight=72.5m,Classes=new List<string>{ "Spinning","Machines"}}
        };
        public ClientEntity GetClient(int clientId)
        {
            return clients.FirstOrDefault(c => c.Id == clientId);
        }
        public ClientEntity CreateClient(ClientEntity clientEntity)
        {
            int clientId;
            if (clients.Count() == 0)
            {
                clientId = 1;
            }
            else
            {
                clientId = clients.OrderByDescending(c => c.Id).FirstOrDefault().Id + 1;
            }
            clientEntity.Id = clientId;
            clients.Add(clientEntity);
            return clientEntity;
        }

        public bool DeleteClient(int clientId)
        {
            var clientToDelete = GetClient(clientId);
            clients.Remove(clientToDelete);
            return true;
        }


        public IEnumerable<ClientEntity> GetClients()
        {
            return clients;
        }


        public ClientEntity UpdateClient(ClientEntity clientEntity)
        {
            var clientToUpdate = GetClient(clientEntity.Id);
            clientToUpdate.Name = clientEntity.Name ?? clientToUpdate.Name;
            clientToUpdate.Ci = clientEntity.Ci ?? clientToUpdate.Ci;
            clientToUpdate.BornDate = clientEntity.BornDate ?? clientToUpdate.BornDate;
            clientToUpdate.Height = clientEntity.Height ?? clientToUpdate.Height;
            clientToUpdate.Weight = clientEntity.Weight ?? clientToUpdate.Weight;
            clientToUpdate.Classes = clientEntity.Classes ?? clientToUpdate.Classes;
            return clientToUpdate;
        }
    }
}
