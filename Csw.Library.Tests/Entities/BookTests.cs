using System.Data.Entity;
using System.Linq;
using Csw.Library.Core.Entities;
using Csw.Library.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Csw.Library.Tests.Entities
{
    [TestClass]
    public class BookTests
    {
        protected CswContext SUT { get; set; }

        protected DbContextTransaction Transaction { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            SUT = new CswContext();
            Transaction = SUT.Database.BeginTransaction();
        }

        [TestMethod]
        public void Can_create_Book_with_new_Author_and_Category()
        {
            var book = new Book
            {
                Title = "TestBook",
                Author = new Author { FirstName = "Author", LastName = "1" },
                Category = new Category { Name = "MyCategory" }
            };

            SUT.Books.Add( book );
            SUT.SaveChanges();

            Assert.IsTrue( SUT.Books.Any() );
        }

        public void CleanUp()
        {
            Transaction?.Rollback();
        }
    }
}
