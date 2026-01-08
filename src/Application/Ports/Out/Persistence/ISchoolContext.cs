using NetCoreHexagonal.Domain.Commons;

namespace NetCoreHexagonal.Application.Ports.Out.Persistence
{
    public interface ISchoolContext
    {
        ICoursesRepository Courses { get; }
        IStudentsRepository Students { get; }
        IBooksRepository Books { get; }

        Task<IReadOnlyList<RootAggregate>> SaveChangesAsync();
    }
}