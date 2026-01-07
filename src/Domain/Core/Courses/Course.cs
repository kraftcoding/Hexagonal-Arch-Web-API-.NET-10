using NetCoreHexagonal.Domain.Commons;

namespace NetCoreHexagonal.Domain.Core.Courses
{
    public class Course : RootAggregate
    {
        public CourseName Name { get; }

        public Course(CourseName name)
        {
            Name = name;
        }

        private Course() { }

    }
}