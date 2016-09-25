using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Csw.Library.Core.Entities;
using Csw.Library.Data;

namespace Csw.Library.Services
{
    public class BookService
    {
        private readonly CswContext _context;

        public BookService( CswContext context )
        {
            _context = context;
        }


        public async Task<IEnumerable<Book>> AllAsync()
        {
            return await _context.Books
                .OrderBy( b => b.Title )
                .ToArrayAsync();
        }

        public async Task<IEnumerable<Book>> GetByAuthor( int authorId )
        {
            return await _context.Books
                .OrderBy( b => b.Title )
                .Where( b => b.AuthorId == authorId )
                .ToArrayAsync();
        }
    }
}