using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Csw.Library.Core.Entities;

namespace Csw.Library.Data
{
    public class CswDbInitializer : CreateDatabaseIfNotExists<CswContext>
    {
        protected override void Seed( CswContext context )
        {
            if ( context.Books.Any() )
                return;

            SeedBoosks( context );

            base.Seed( context );
        }

        private static void SeedBoosks( CswContext context )
        {
            var author1 = new Author { FirstName = "Author 2", LastName = "Test 1" };
            var author2 = new Author { FirstName = "Author 2", LastName = "Test 2" };

            var category1 = new Category { Name = "Category 1" };
            var category2 = new Category { Name = "Category 2" };

            var books = new List<Book>();

            for (var i = 0; i < 20; i++)
            {
                books.Add(new Book
                {
                    Title = "Book " + (i+1),
                    Author = i % 2 == 0 || i > 5 ? author1 : author2,
                    Category = i % 2 == 0 ? category1 : category2
                });
            }

            context.Books.AddRange( books );
            context.SaveChanges();
        }
    }
}