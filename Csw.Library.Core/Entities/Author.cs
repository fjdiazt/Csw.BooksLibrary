using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Csw.Library.Core.Entities
{
    public class Author : Entity
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}