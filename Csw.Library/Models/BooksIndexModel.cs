using System.Collections.Generic;
using Csw.Library.Core.Entities;

namespace Csw.Library.Models
{
    public class BooksIndexModel
    {
        public IEnumerable<Author> Authors { get; set; }

        public IEnumerable<Book> Books { get; set; }
    }
}
