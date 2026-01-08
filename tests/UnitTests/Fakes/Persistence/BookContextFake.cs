using NetCoreHexagonal.Application.Ports.Out.Persistence;
using NetCoreHexagonal.Domain.Core.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreHexagonal.UnitTests.Fakes.Persistence
{
    internal class BooksRepositoryFake : IBooksRepository
    {
        private readonly Dictionary<string, Book> Books = new();

        public Task<IReadOnlyList<Book>> GetAllAsync()
        {
            return Task.FromResult(Books.Values.ToList() as IReadOnlyList<Book>);
        }

        public ValueTask<Book?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Book?> GetByNameAsync(BookName name)
        {
            if (Books.TryGetValue(name.Name, out Book? Book))
                return Task.FromResult<Book?>(Book);
            return Task.FromResult<Book?>(null);
        }

        public void Register(Book Book)
        {
            Books.Add(Book.Name.Name, Book);
        }

        Task<Book?> IBooksRepository.GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
