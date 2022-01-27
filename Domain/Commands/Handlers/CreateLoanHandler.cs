using Domain.Commands.Requests;
using Domain.Commands.Response;
using Infra.Models;
using Infra.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.Handlers
{
    public class CreateLoanHandler : IRequestHandler<CreateLoanRequest, CreateLoanResponse>
    {
        private readonly ILoanRepository _repo;
        private readonly IClientRepository _clientRepo;
        private readonly IBookRepository _bookRepo;
        public CreateLoanHandler(ILoanRepository repo,
            IClientRepository clientRepo,
            IBookRepository bookRepo)
        {
            _bookRepo = bookRepo;
            _repo = repo;
            _clientRepo = clientRepo;
        }
        public async Task<CreateLoanResponse> Handle(CreateLoanRequest request, CancellationToken cancellationToken)
        {
            var loanResponse = new CreateLoanResponse();
            if (request.Books.Count < 0) loanResponse.Errors.Add("It's impossible to create a loan with no books");

            if(!await _clientRepo.EntityExists(request.ClientId))
            {
                loanResponse.Errors.Add("This client don't exists!");
                return loanResponse;
            }
            var loan = new Loan(0, request.ClientId, request.Start_Date, request.Devolution_Date, false);

            var insert = await _repo.Add(loan);
            if(insert != null)
            {
                loanResponse.SetSuccess(insert.Id, insert.ClientId, insert.Start_Date, insert.Devolution_Date);
                return loanResponse;
            }
            loanResponse.SetInternalError();
            return loanResponse;
            
        }

        private async Task<IEnumerable<Book>> BookDtoToModel(IEnumerable<Dto.BookDto> books)
        {
            var list = new List<Book>();
            foreach(var item in books)
            {
                var book = await _bookRepo.Get(item.BookId);
                if (book != null) list.Add(book);
            }
            return list;
        }
    }
}
