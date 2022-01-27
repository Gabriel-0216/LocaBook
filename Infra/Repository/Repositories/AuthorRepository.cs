using Infra.Data;
using Infra.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _context;
        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Author>> Get()
        {
            return await _context.Authors
                .AsNoTracking().ToListAsync();
        }

        public async Task<Author?> Add(Author entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            var get = await _context.Authors
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == entity.Id);
            return get;
        }

        public Task<bool> Delete(Author entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EntityExists(int id)
        {
            var get = await _context.Authors
                .FirstOrDefaultAsync(p=> p.Id == id);
            return get != null;
        }

        public async Task<Author?> Get(int id)
        {
            return await _context.Authors.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Author>> Get(bool includeBooks, int skip, int take)
        {
            IQueryable<Author> query = _context.Authors;
            if (includeBooks) query = query.Include(p => p.Books);

            return await query
                .AsNoTracking()
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        public async Task<Author?> Update(Author entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
