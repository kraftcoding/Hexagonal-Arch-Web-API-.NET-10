using NetCoreHexagonal.Domain.Commons;

namespace NetCoreHexagonal.Domain.Core.Books
{
    public sealed record class BookName(string Name) : NotNullOrWhiteSpaceText(Name);

    public static partial class StringExtensions
    {
        public static BookName ToBookName(this string name) => new(name);
    }
}
