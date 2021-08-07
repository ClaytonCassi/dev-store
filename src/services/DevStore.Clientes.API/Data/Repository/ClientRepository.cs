using DevStore.Clients.API.Models;
using DevStore.Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevStore.Clients.API.Data.Repository
{
    public class ClientRepository : IClienteRepository
    {
        private readonly ClientContext _context;

        public ClientRepository(ClientContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await _context.Clients.AsNoTracking().ToListAsync();
        }

        public Task<Client> GetBySocialNumber(string ssn)
        {
            return _context.Clients.FirstOrDefaultAsync(c => c.SocialNumber == ssn);
        }

        public void Add(Client client)
        {
            _context.Clients.Add(client);
        }

        public async Task<Address> GetAddressById(Guid id)
        {
            return await _context.Addresses.FirstOrDefaultAsync(e => e.ClientId == id);
        }

        public void AddAddress(Address address)
        {
            _context.Addresses.Add(address);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}