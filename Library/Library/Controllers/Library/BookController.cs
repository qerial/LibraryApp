using Library.ApplicationServices.Services;
using Library.Core.Dto;
using Library.Core.ServiceInterface;
using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Index()
        {
            var result = _context.Books
            .Select(x => new BookIndexViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Author = x.Author,
                PublishedYear = x.PublishedYear,
                IsAvailable = x.IsAvailable
            });



            return View(result);
        }

        // kui oled teinud vormi, siis see meetod käivitatakse
        // saadab andmed serverisse, kus need salvestatakse andmebaasi
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
                    PublishedYear = vm.PublishedYear,
                    IsAvailable = vm.IsAvailable
                };



                var result = await _bookServices.Create(dto);

                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }
    }
}
