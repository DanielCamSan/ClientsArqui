using AutoMapper;
using Practicando_WEBAPI.Data.Entities;
using Practicando_WEBAPI.Data.Repository;
using Practicando_WEBAPI.Exceptions;
using Practicando_WEBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practicando_WEBAPI.Services
{
    public class ClientService : IClientService
    {
        private ILibraryRepository _libraryRepository;
        private IMapper _mapper;

        public ClientService(ILibraryRepository libraryRepository, IMapper _mapper)
        {
            this._libraryRepository = libraryRepository;
            this._mapper = _mapper;
        }

        public IEnumerable<ClientModel> GetClients()
        {
            var entityList= _libraryRepository.GetClients();
            var modelList = _mapper.Map<IEnumerable<ClientModel>>(entityList);
            return modelList;
        }
        public ClientModel GetClient(int clientId)
        {
            var client = _libraryRepository.GetClient(clientId);

            if (client == null)
            {
                throw new NotFoundException($"The client {clientId} doesnt exists, try it with a new id");
            }

            return _mapper.Map<ClientModel>(client);
        }
      
        public ClientModel CreateClient(ClientModel clientModel)
        {

            var entityreturned=_libraryRepository.CreateClient(_mapper.Map<ClientEntity>(clientModel));
            
            return _mapper.Map<ClientModel>(entityreturned);
        }

        public bool DeleteClient(int clientId)
        {
            var clientToDelete = GetClient(clientId);
            return _libraryRepository.DeleteClient(clientId);
        }

        public ClientModel UpdateClient(int ClientId, ClientModel clientModel)
        {
            clientModel.Id = ClientId;
            var clientToUpdate=_libraryRepository.UpdateClient(_mapper.Map<ClientEntity>(clientModel));

            return _mapper.Map<ClientModel>(clientToUpdate);
        }
    }
}
