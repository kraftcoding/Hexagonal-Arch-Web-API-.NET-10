using NetCoreHexagonal.Application.Ports.In;
using NetCoreHexagonal.Application.Ports.In.Dtos;
using NetCoreHexagonal.Application.Services.Context;
using NetCoreHexagonal.Domain.Core.Courses;
using NetCoreHexagonal.Domain.Core.Students;
using NetCoreHexagonal.Domain.Core.Books;

namespace NetCoreHexagonal.Application.Services
{
    internal sealed class SchoolService : ISchoolService
    {
        private readonly ISchoolContextWithEvents context;

        public SchoolService(ISchoolContextWithEvents context)
        {
            this.context = context;
        }

        public async Task<IReadOnlyList<CourseDto>> GetAllCourses()
        {
            var courses = await context.School.Courses.GetAllAsync();
            return courses.Select(c => c.ToDto()).ToList();
        }

        public async Task<IReadOnlyList<StudentDto>> GetAllStudents()
        {
            var students = await context.School.Students.GetAllAsync();
            return students.Select(s => s.ToDto()).ToList();
        }

        public async Task<CourseDto> RegisterCourse(RegisterCourseDto dto)
        {
            var course = dto.ToCourse();
            context.School.Courses.Register(course);
            await context.SaveChangesAndDispatchEventsAsync();
            return course.ToDto();
        }

        public async Task<StudentDto?> RegisterStudent(RegisterStudentDto dto)
        {
            var student = await dto.ToStudent(context.School.Courses);
            if (student == null)
                return null;

            context.School.Students.Register(student);
            await context.SaveChangesAndDispatchEventsAsync();
            return student.ToDto();
        }

        public async Task EnrollStudent(EnrollStudentDto dto)
        {
            var course = await context.School.Courses.GetByNameAsync(dto.CourseName.ToCourseName());
            var book = await context.School.Books.GetByNameAsync(dto.BookName.ToBookName());
            var student = await context.School.Students.GetByNameAsync(dto.StudentName.ToStudentName());
            if (student == null || course == null || book == null)
                return;

            student.EnrollIn(course, book);
            await context.SaveChangesAndDispatchEventsAsync();
        }

        public async Task<BookDto> RegisterBook(RegisterBookDto dto)
        {
            var book = dto.ToBook();
            context.School.Books.Register(book);
            await context.SaveChangesAndDispatchEventsAsync();
            return book.ToDto();
        }

        public async Task<IReadOnlyList<BookDto>> GetAllBooks()
        {
            var books = await context.School.Books.GetAllAsync();
            return books.Select(c => c.ToDto()).ToList();
        }      

    }
}
