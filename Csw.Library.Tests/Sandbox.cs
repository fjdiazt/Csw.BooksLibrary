using Csw.Library.Core.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Csw.Library.Tests
{
    [TestClass]
    public class Sandbox
    {
        [TestMethod]
        public void Test()
        {
            var book = new Book();

            book.Description = "lasjhdlajsd";
            book.Author = new Author {FirstName = "asda", LastName = "asda"};
            book.Category = new Category() {Name="asda"};

        }
    }
}
