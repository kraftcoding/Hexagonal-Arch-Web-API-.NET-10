using NetCoreHexagonal.Domain.Commons;

namespace NetCoreHexagonal.Domain.Core.Books
{
    public class Book : RootAggregate
    {
        public BookName Name { get; }

        public Book(BookName name)
        {
            Name = name;
        }

        private Book() { }

    }
}