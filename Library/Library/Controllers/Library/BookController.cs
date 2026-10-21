
using Library.ApplicationServices.Services;
using Library.Core.Dto;
using Library.Core.ServiceInterface;
using Library.Data;
using Library.LINQ;
using Library.Models;
using Library.Models.Book;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Library.Controllers.Library
{
    public class BookController : Controller
    {
        private readonly IBookServices _bookServices;
        private readonly LibraryContext _context;

        public BookController
        (
            IBookServices bookServices,
            LibraryContext context
        )
        {
            _bookServices = bookServices;
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            BookCreateViewModel vm = new();

            return View(vm);
        }

        public IActionResult Index(string? year, string? title, bool borrowedOnly = false)
        {
            var books = _context.Books.ToList();
            var sorting = new LINQSorting();

            if (!string.IsNullOrWhiteSpace(year))
            {
                books = sorting.FindBooksByYear(books, year);
            }

            if (!string.IsNullOrWhiteSpace(title))
            {
                books = sorting.FindBooksTitle(books, title.Trim());
            }

            if (borrowedOnly)
            {
                books = sorting.UnavaliableBooks(books);
            }

            var result = books.Select(x => new BookIndexViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Author = x.Author,
                PublishedYear = x.PublishedYear,
                IsAvailable = x.IsAvailable
            }).ToList();

            ViewBag.Year = year;
            ViewBag.TitleSearch = title;
            ViewBag.BorrowedOnly = borrowedOnly;

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var dto = new BookDto
                {
                    Id = vm.Id,
                    Title = vm.Title,
                    Author = vm.Author,
                    PublishedYear = vm.PublishedYear
                };

                var result = await _bookServices.Create(dto);

                return RedirectToAction(nameof(Index));
            }

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            var vm = new UpdateBookTitleViewModel();
            {
                vm.Id = book.Id;
                vm.Title = book.Title;

                return View(vm);
            }
        }
            [HttpPost]
        public async Task<IActionResult> Update(UpdateBookTitleViewModel vm)
        {
            var dto = new BookDto()
            {
                Id = vm.Id,
                Title = vm.Title
            };

            var result = await _bookServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]

        public async Task<IActionResult> Delete(Guid Id)
        {
            var book = await _bookServices.Delete(Id);
            if (book == null)
            {
                return NotFound();
            }

            var vm = new DeleteViewModel();

            vm.Id = book.Id;
            vm.Title = book.Title;
            vm.Author = book.Author;
            vm.PublishedYear = book.PublishedYear;
            vm.IsAvailable = book.IsAvailable;



            return View(vm);

        }

        [HttpPost]

        public async Task<IActionResult> DeleteConfirmation(Guid Id)
        {
            var result = await _bookServices.Delete(Id);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));

            }
            return RedirectToAction(nameof(Index));
        }
    }
}
