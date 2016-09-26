using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Csw.Library.Core.Entities;
using Csw.Library.Data;
using Csw.Library.Models;
using Csw.Library.Services;

namespace Csw.Library.Controllers
{
    public class BooksController : Controller
    {
        private readonly CswContext _db;

        // GET: Books
        private BookService BookService { get; set; }

        private AuthorService AuthorService { get; set; }

        public BooksController()
        {
            _db = new CswContext();
            BookService = new BookService( _db );
            AuthorService = new AuthorService( _db );
        }

        public async Task<ActionResult> Index()
        {
            var model = new BooksIndexModel
            {
                Books = await BookService.GetAllAsync(),
                Authors = await AuthorService.AllAsync(),
            };

            return View( model );
        }

        public async Task<ActionResult> BooksByAuthor( int authorId )
        {
            var books = authorId == 0
                ? await BookService.GetAllAsync()
                : await BookService.GetByAuthorAsync( authorId );

            return View( "Books", books );
        }

        // GET: Books/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = await _db.Books.FindAsync(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(_db.Authors, "Id", "FirstName");
            ViewBag.CategoryId = new SelectList(_db.Categories, "Id", "Name");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Title,Description,AuthorId,CategoryId")] Book book)
        {
            if (ModelState.IsValid)
            {
                _db.Books.Add(book);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(_db.Authors, "Id", "FirstName", book.AuthorId);
            ViewBag.CategoryId = new SelectList(_db.Categories, "Id", "Name", book.CategoryId);
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = await _db.Books.FindAsync(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(_db.Authors, "Id", "FirstName", book.AuthorId);
            ViewBag.CategoryId = new SelectList(_db.Categories, "Id", "Name", book.CategoryId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,Description,AuthorId,CategoryId")] Book book)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(book).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(_db.Authors, "Id", "FirstName", book.AuthorId);
            ViewBag.CategoryId = new SelectList(_db.Categories, "Id", "Name", book.CategoryId);
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = await _db.Books.FindAsync(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Book book = await _db.Books.FindAsync(id);
            _db.Books.Remove(book);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
