using System.ComponentModel.DataAnnotations;

namespace Csw.Library.Core.Entities
{
    public class Book : Entity
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
