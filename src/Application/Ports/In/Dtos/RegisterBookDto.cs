using NetCoreHexagonal.Domain.Core.Books;

namespace NetCoreHexagonal.Application.Ports.In.Dtos
{
    public sealed record class RegisterBookDto(string Name)
    {
        public Book ToBook() => new(Name.ToBookName());
    }
}
