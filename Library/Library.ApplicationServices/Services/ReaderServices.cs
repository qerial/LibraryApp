using Library.Core.Domain;
using Library.Core.Dto;
using Library.Core.ServiceInterface;
using Library.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.ApplicationServices.Services
{
    public class ReaderServices : IReaderServices
    {
        private readonly LibraryContext _context;

        public ReaderServices(LibraryContext context)
        {
            _context = context;
        }

        public async Task<ReaderDomain> Create(ReaderDto dto)
        {
            ReaderDomain domain = new();

            domain.Id = Guid.NewGuid();
            domain.FullName = dto.FullName;
            domain.Email = dto.Email;

            await _context.Readers.AddAsync(domain);
            await _context.SaveChangesAsync();

            return domain;
        }

    }
}