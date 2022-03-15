using MinimalRestDemo.DAL.Models;

namespace MinimalRestDemo.DAL;

public class UserStorage
{
    private readonly UserCourseDemoDbContext _context;

    public UserStorage(UserCourseDemoDbContext context)
    {
        _context = context;
    }

    public bool CreateUser(User user)
    {
        if (_context.Users.Any(u => u.Email == user.Email)) return false;

        _context.Users.Add(user);
        _context.SaveChanges();
        return true;
    }

    public ICollection<User> GetAllUsers()
    {
        return _context.Users.ToList();
    }

    public User? GetUser(int id)
    {
        return _context.Users.Find(id);
    }

    public bool UpdateUser(int id, User user)
    {
        var existingUser = _context.Users.Find(id);
        if (existingUser is null) return false;

        existingUser.Name = user.Name;
        existingUser.Email = user.Email;
        _context.SaveChanges();
        return true;
    }

    public bool UpdateUserName(int id, string name)
    {
        var user = _context.Users.Find(id);
        if (user is null) return false;

        user.Name = name;
        _context.SaveChanges();
        return true;
    }

    public bool UpdateUserEmail(int id, string email)
    {
        var user = _context.Users.Find(id);
        if (user != null)
        {
            user.Email = email;
            _context.SaveChanges();
            return true;
        }

        return false;
    }

    public bool DeleteUser(int id)
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