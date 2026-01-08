using NetCoreHexagonal.Application.Ports.Out.Persistence;
using NetCoreHexagonal.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCoreHexagonal.UnitTests.Fakes.Persistence
{
    internal sealed class SchoolContextFake : ISchoolContext
    {
        public IStudentsRepository Students { get; }
        public ICoursesRepository Courses { get; }

        public IBooksRepository Books { get; }

        public SchoolContextFake()
        {
            Students = new StudentsRepositoryFake();
            Courses = new CoursesRepositoryFake();
            Books = new BooksRepositoryFake();
        }

        public void Dispose()
        {
            // Method intentionally left empty.
        }

        public Task<IReadOnlyList<RootAggregate>> SaveChangesAsync()
        {
            return Task.FromResult((IReadOnlyList<RootAggregate>)Array.Empty<RootAggregate>());
        }
    }
}
