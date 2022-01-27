using Infra.Data;
using Infra.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;
        public BookRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Book?> Add(Book entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public Task<bool> Delete(Book entity)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> EntityExists(int id)
        {
            var get = await _context.Books.FirstOrDefaultAsync(p => p.Id == id);
            return get != null;
        }

        public async Task<IEnumerable<Book>> Get(bool includeAuthor, int skip, int take)
        {
            IQueryable<Book> query = _context.Books;
            if (includeAuthor) query = query.Include(p => p.Author);

            return await query
                .AsNoTracking()
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        public async Task<Book?> Get(int id)
        {
            return await _context.Books
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<IEnumerable<Book>> Get()
        {
            return await _context.Books
                .Include(p=> p.Author)
                .Include(p=> p.Loans)
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<Book?> Update(Book entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return await _context.Books.FirstOrDefaultAsync(p => p.Id == entity.Id);
        }
    }
}
