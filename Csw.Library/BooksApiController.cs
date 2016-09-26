using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using Csw.Library.Core.Entities;
using Csw.Library.Data;

namespace Csw.Library
{
    [RoutePrefix("/api")]
    public class BooksApiController : ApiController
    {
        private CswContext db = new CswContext();

        [Route("books")]
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await db.Books.ToArrayAsync();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}