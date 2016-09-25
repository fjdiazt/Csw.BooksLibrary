namespace Csw.Library.Core.Entities
{
    public class Book : Entity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
