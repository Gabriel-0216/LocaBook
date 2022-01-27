using Infra.Data;
using Infra.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly AppDbContext _context;
        public LoanRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Loan?> Add(Loan entity)
        {
            var bookList = new List<Book>();
            foreach(var item in entity.Books)
            {
                var book = await _context.Books.FirstOrDefaultAsync(p => p.Id == item.Id);
                if (book != null) bookList.Add(book);
            }
            var newLoan = new Loan()
            {
                Start_Date = entity.Start_Date,
                ClientId = entity.ClientId,
                Books = bookList,
                Devolution_Date = entity.Devolution_Date,
                IsFinished = entity.IsFinished,
            };

            _context.Add(newLoan);
            await _context.SaveChangesAsync();
            return entity;
        }
        public Task<bool> Delete(Loan entity)
        {
            throw new NotImplementedException();
        }
        public Task<bool> EntityExists(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<Loan?> Get(int id)
        {
            return await _context.Loans
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<IEnumerable<Loan>> Get()
        {
            return await _context.Loans
                .AsNoTracking()
                .Include(p=> p.Books)
                .Include(p=> p.Client)
                .ToListAsync();
        }
        public async Task<IEnumerable<Loan>> GetCompletedLoans(bool includeBooks, bool includeClient, 
            int skip, int take)
        {
            IQueryable<Loan> query = _context.Loans;
            if (includeBooks) query = query.Include(p => p.Books);
            if (includeClient) query = query.Include((p => p.Client));

            return await query
                .Where(p => p.IsFinished == true)
                .AsNoTracking()
                .ToListAsync();
        }
        public Task<IEnumerable<Loan>> GetLateDevolutions(bool includeBooks, bool includeClient)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Loan>> Get(bool includeBooks, bool includeClient, int skip, int take)
        {
            IQueryable<Loan> query = _context.Loans;
            if (includeBooks) query = query.Include((p => p.Books));
            if (includeClient) query = query.Include((p => p.Client));
            
            return await query
                .AsNoTracking()
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        public async Task<IEnumerable<Loan>> GetUnfinishedLoans(bool includeBooks, bool includeClient,
            int skip, int take)
        {
            IQueryable<Loan> query = _context.Loans;
            if (includeBooks) query = query.Include(p => p.Books);
            if (includeClient) query = query.Include(p => p.Client);
            return await query
                .Where(p => p.IsFinished == false)
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<Loan?> Update(Loan entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return await Get(entity.Id);;
        }
    }
}