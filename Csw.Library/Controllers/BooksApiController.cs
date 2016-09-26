using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Csw.Library.Core.Entities;
using Csw.Library.Data;
using Csw.Library.Services;

namespace Csw.Library.Controllers
{
    [RoutePrefix("api/books")]
    public class BooksApiController : ApiController
    {
        private readonly CswContext _db;

        private BookService BooksService { get; set; }

        public BooksApiController()
        {
            _db = new CswContext();
            _db.Configuration.ProxyCreationEnabled = false;
            _db.Configuration.LazyLoadingEnabled = false;
            BooksService = new BookService(_db);
        }        

        [Route("all")]
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await BooksService.GetAllAsync();
        }

        [Route("author/{authorId:int}")]
        public async Task<IEnumerable<Book>> GetBooksByAuthor(int authorId)
        {
            return await BooksService.GetByAuthorAsync(authorId);
        }

        [Route( "category/{categoryId:int}" )]
        public async Task<IEnumerable<Book>> GetBooksByCategory(int categoryId)
        {
            return await BooksService.GetByCategoryAsync(categoryId);
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