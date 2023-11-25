using LibApp.Data;
using LibApp.Models;
using LibApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibApp.Controllers
{
    public class BooksController : Controller
    {
        public BooksController(ApplicationDbContext dbContext) { 
            _context = dbContext;
        }

        // GET: BooksController/{pageIndex}&{sortBy}
        public IActionResult Index(int? pageIndex, string sortBy)
        {
            var books = _context.Books
                .Include(b => b.Genre)
                .ToList();

            return View(books);
        }

        // GET: BooksController/Details/5
        public IActionResult Details(int id)
        {
            var book = _context.Books
                .Include(c => c.Genre)
                .SingleOrDefault(c => c.Id == id);

            if (book == null)
            {
                return Content("Book not found");
            }

            return View(book);
        }

        // GET: BooksController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BooksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BooksController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BooksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BooksController/Random
        public IActionResult Random()
        {
            var firstBook = new Book() { Author = "Random author", Title = "Random title" };

            // ViewBag.Book = firstBook;
            // ViewData["FirstBook"] = firstBook;

            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var randomBookViewModel = new RandomBooksViewModel
            {
                Book = firstBook,
                Customers = customers
            };

            return View(randomBookViewModel);
            //return RedirectToAction("Index", "Book", new { page = 1, sortBy = "title" });
        }

        // GET: BooksController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BooksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private ApplicationDbContext _context;
    }
}
