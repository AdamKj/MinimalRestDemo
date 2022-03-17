namespace MinimalRestDemo.DAL
{
    public class UnitOfWork : IDisposable
    {
        private readonly UserCourseDemoDbContext _context;

        private IUserRepository _userRepository;

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_context);
                }

                return _userRepository;
            }
        }

        public UnitOfWork(UserCourseDemoDbContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
            _userRepository.Dispose();
        }
    }
}
