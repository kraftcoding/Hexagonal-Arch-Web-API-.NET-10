using NetCoreHexagonal.Domain.Commons;
using NetCoreHexagonal.Domain.Core.Books;
using NetCoreHexagonal.Domain.Core.Courses;

namespace NetCoreHexagonal.Domain.Core.Students
{
    public class Enrollment : Entity
    {
        public Student Student { get; }
        public Course Course { get; }
        public Book Book { get; }

        public Enrollment(Student student, Course course, Book book)
        {
            Student = student;
            Course = course;
            Book = book;
        }

       
        private Enrollment() { }

    }
}