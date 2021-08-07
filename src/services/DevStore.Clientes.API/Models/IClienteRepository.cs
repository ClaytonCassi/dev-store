using DevStore.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevStore.Clients.API.Models
{
    public interface IClienteRepository : IRepository<Client>
    {
        void Add(Client client);

        Task<IEnumerable<Client>> GetAll();
        Task<Client> GetBySocialNumber(string ssn);

        void AddAddress(Address address);
        Task<Address> GetAddressById(Guid id);
    }
}