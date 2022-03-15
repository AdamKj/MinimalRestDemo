using MinimalRestDemo.DAL.Models;

namespace MinimalRestDemo.DAL;

public class CourseStorage
{
    private readonly UserCourseDemoDbContext _context;

    public CourseStorage(UserCourseDemoDbContext context)
    {
        _context = context;
    }

    public bool CreateCourse(Course course)
    {
        if (_context.Users.Any(c => c.Name == course.Name)) return false;

        _context.Courses.Add(course);
        _context.SaveChanges();
        return true;
    }

    public ICollection<Course> GetAllCourses()
    {
        return _context.Courses.ToList();
    }

    public Course? GetCourse(int id)
    {
        return _context.Courses.Find(id);
    }

    public bool UpdateCourse(int id, Course course)
    {
        var existingCourse = _context.Courses.Find(id);
        if (existingCourse is null) return false;

        existingCourse.Name = course.Name;
        _context.SaveChanges();
        return true;
    }

    public bool UpdateCourseName(int id, string name)
    {
        var user = _context.Users.Find(id);
        if (user is null) return false;

        user.Name = name;
        _context.SaveChanges();
        return true;
    }

    public bool DeleteCourse(int id)
    {
        var user = _context.Users.Find(id);
        if (user != null)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }

        return false;
    }
}