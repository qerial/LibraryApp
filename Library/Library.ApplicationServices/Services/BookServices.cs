using Microsoft.EntityFrameworkCore;
using Library.Core.Domain;
using Library.Core.Dto;
using Library.Core.ServiceInterface;
using Library.Data;

namespace Library.ApplicationServices.Services
{
    public class BookServices : IBookServices
    {
        private readonly LibraryContext _context;

        public BookServices(LibraryContext context)
        {
            _context = context;
        }

        public async Task<BookDomain> Create(BookDto dto)
        {
            BookDomain domain = new();

            domain.Id = Guid.NewGuid();
            domain.Title = dto.Title;
            domain.Author = dto.Author;
            domain.PublishedYear = dto.PublishedYear;
            domain.IsAvailable = true;

            await _context.Books.AddAsync(domain);
            await _context.SaveChangesAsync();

            return domain;
        }

    }
}