using System.Collections.Generic;

namespace Csw.Library.Core.Entities
{
    public class Category : Entity
    {

        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}