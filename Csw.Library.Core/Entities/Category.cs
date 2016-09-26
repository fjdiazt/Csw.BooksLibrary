using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Csw.Library.Core.Entities
{
    public class Category : Entity
    {
        [Required]
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}