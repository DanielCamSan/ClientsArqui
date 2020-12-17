using Practicando_WEBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practicando_WEBAPI.Services
{
    public interface IClientService
    {
        public IEnumerable<ClientModel> GetClients();
        public ClientModel GetClient(int ClientId);
        public ClientModel CreateClient(ClientModel clientModel);
        public bool DeleteClient(int ClientId);
        public ClientModel UpdateClient(int ClientId, ClientModel clientModel);
    }
}
