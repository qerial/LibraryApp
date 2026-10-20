using Library.Core.Domain;
using Library.Core.Dto;
using Library.Core.ServiceInterface;
using Library.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.ApplicationServices.Services
{
    public class LoanServices : ILoanServices
    {
        private readonly LibraryContext _context;

        public LoanServices(LibraryContext context)
        {
            _context = context;
        }

        public async Task<LoanDomain> Create(LoanDto dto)
        {
            LoanDomain domain = new();

            domain.Id = Guid.NewGuid();
            domain.BookId = dto.BookId;
            domain.ReaderId = dto.ReaderId;
            domain.LoanDate = dto.LoanDate;
            domain.ReturnDate = dto.ReturnDate;

            await _context.Loans.AddAsync(domain);
            await _context.SaveChangesAsync();

            return domain;
        }

    }
}