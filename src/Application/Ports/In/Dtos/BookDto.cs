using NetCoreHexagonal.Domain.Core.Books;

namespace NetCoreHexagonal.Application.Ports.In.Dtos
{
    public sealed record class BookDto(string Name);

    public static class BookExtensions
    {
        public static BookDto ToDto(this Book Book) => new BookDto(Book.Name.Name);
    }
}
