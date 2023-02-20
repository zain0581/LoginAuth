using LoginAuth.Context;

namespace LoginAuth.Models
{
    public class UserService : IUser
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public void Adduser(User user)
        {
            var newuser = _context.Add(user);
            _context.SaveChanges();
           
        }

        
        public ICollection<User> GetUsers()
        {
            return _context.User.OrderBy(c => c.ID).ToList();
        }

    }

}
