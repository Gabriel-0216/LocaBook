using Domain.Commands.Response;
using Domain.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.Requests
{
    public class CreateLoanRequest : IRequest<CreateLoanResponse>
    {
        public CreateLoanRequest()
        {
            Books = new List<BookDto>();
        }
        public int ClientId { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime Devolution_Date { get; set; }
        public List<BookDto> Books { get; set; }
    }
  
}
