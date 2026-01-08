using NetCoreHexagonal.Domain.Core.Books;

namespace NetCoreHexagonal.Application.Ports.Out.Persistence
{
    public interface IBooksRepository
    {
        Task<IReadOnlyList<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(Guid id);
        Task<Book?> GetByNameAsync(BookName name);
        void Register(Book Book);
    }
}
