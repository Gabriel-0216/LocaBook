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
    public class CreateBookHandler : IRequestHandler<CreateBookRequest, CreateBookResponse>
    {
        private readonly IBookRepository _repo;
        private readonly IAuthorRepository _authorRepo;
        public CreateBookHandler(IBookRepository repo, IAuthorRepository authorRepo)
        {
            _repo = repo;
            _authorRepo = authorRepo;
        }
        public async Task<CreateBookResponse> Handle(CreateBookRequest request, CancellationToken cancellationToken)
        {
            var response = new CreateBookResponse();
            if (string.IsNullOrWhiteSpace(request.Title)) response.Errors.Add("book title cannot be empty or null");
            if (string.IsNullOrWhiteSpace(request.Resume)) response.Errors.Add("book resume cannot be empty or null");

            if (response.Errors.Count > 0) return response;

            if (!await _authorRepo.EntityExists(request.AuthorId))
            {
                response.Errors.Add("This author don't exists");
                return response;
            }

            var inserted = await _repo.Add(new Book(0,request.Title, request.Resume, DateTime.Now, request.AuthorId));
            if(inserted != null)
            {
                response.SetSuccess(inserted.Id, inserted.Title, inserted.Resume, inserted.CreateDate, inserted.AuthorId);
                return response;
            }
            response.SetInternalError();
            return response;
        }
    }
}
