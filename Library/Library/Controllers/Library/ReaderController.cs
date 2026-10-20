
using Library.Core.Domain;
using Library.Data;
using Library.Models.Reader;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers.Library
{
    public class ReaderController : Controller
    {
        private readonly LibraryContext _context;

        public ReaderController(LibraryContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var result = _context.Readers
                .Select(x => new ReaderIndexViewModel
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    Email = x.Email
                })
                .ToList();

            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new ReaderCreateViewModel());
        }

        [HttpPost]
        public IActionResult Create(ReaderCreateViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var reader = new ReaderDomain
            {
                Id = Guid.NewGuid(),
                FullName = vm.FullName,
                Email = vm.Email
            };

            _context.Readers.Add(reader);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
