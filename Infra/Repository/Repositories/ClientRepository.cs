using Infra.Data;
using Infra.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _context;

        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Client?> Add(Client entity)
        {
            _context.Clients.Add(entity);
            await _context.SaveChangesAsync();
            var get = await _context.Clients.FirstOrDefaultAsync(p=> p.Id == entity.Id);
            return get;
        }
        public Task<bool> Delete(Client entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EntityExists(int id)
        {
            var get = await _context.Clients.FirstOrDefaultAsync(p => p.Id == id);
            return get != null;
        }

        public async Task<Client?> Get(int id)
        {
            return await _context.Clients.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Client>> Get()
        {
            return await _context.Clients
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<Client?> Update(Client entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<IEnumerable<Client>> Get(bool includeLoans, bool onlyActiveLoans,
            int skip, int take)
        {
            IQueryable<Client> query = _context.Clients;
            if (includeLoans) query = query.Include(p => p.Loans);
            if (includeLoans && onlyActiveLoans)
            {
                query = query.Include(p => p.Loans.Where(loan => loan.IsFinished.Equals(onlyActiveLoans)));
            }

            return await query
                .AsNoTracking()
                .Skip(skip)
                .Take(take)
                .ToListAsync();
                
        }
        
    }
}
