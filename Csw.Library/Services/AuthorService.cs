using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Csw.Library.Core.Entities;
using Csw.Library.Data;

namespace Csw.Library.Services
{
    public class AuthorService
    {
        private readonly CswContext _context;

        public AuthorService( CswContext context )
        {
            _context = context;
        }

        public async Task<IEnumerable<Author>> AllAsync()
        {
            return await _context.Authors.ToArrayAsync();
        }
    }
}