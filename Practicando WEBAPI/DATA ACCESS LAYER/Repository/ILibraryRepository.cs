using Practicando_WEBAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practicando_WEBAPI.Data.Repository
{
    public interface ILibraryRepository
    {
        public IEnumerable<ClientEntity> GetClients();
        public ClientEntity GetClient(int clientId);
        public ClientEntity CreateClient(ClientEntity clientEntity);
        public bool DeleteClient(int clientId);
        public ClientEntity UpdateClient(ClientEntity clientEntity);
    }
}
