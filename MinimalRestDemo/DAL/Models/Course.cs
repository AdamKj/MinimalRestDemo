namespace MinimalRestDemo.DAL.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }

        public Course()
        {
            Users = new List<User>();
        }
    }
}
