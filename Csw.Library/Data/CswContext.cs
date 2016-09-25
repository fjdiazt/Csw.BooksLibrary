using System.Data.Entity;
using Csw.Library.Core.Entities;

namespace Csw.Library.Data
{
    public class CswContext : DbContext
    {
        public CswContext()
            : base( "CswConnection" )
        {
        }

        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<Author> Authors { get; set; }

        public virtual DbSet<Category> Categories { get; set; }
    }
}
