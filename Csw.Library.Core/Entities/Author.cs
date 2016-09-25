using System.Collections.Generic;

namespace Csw.Library.Core.Entities
{
    public class Author : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}