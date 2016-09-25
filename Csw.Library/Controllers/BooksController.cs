using System.Threading.Tasks;
using System.Web.Mvc;
using Csw.Library.Data;
using Csw.Library.Models;
using Csw.Library.Services;

namespace Csw.Library.Controllers
{
    public class BooksController : Controller
    {
        private BookService BookService { get; set; }

        private AuthorService AuthorService { get; set; }

        public BooksController()
        {
            var context = new CswContext();
            BookService = new BookService( context );
            AuthorService = new AuthorService( context );
        }

        public async Task<ActionResult> Index()
        {
            var model = new BooksIndexModel
            {
                Books = await BookService.AllAsync(),
                Authors = await AuthorService.AllAsync(),
            };

            return View( model );
        }
    }
}
