using WebApplicationORM.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplicationORM.Repository
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // 🟩 Get all users
        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        // 🟦 Add a new user
        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        // 🟧 Update user
        public void Update(User user)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser != null)
            {
                existingUser.Email = user.Email;
                existingUser.Password = user.Password;
                _context.SaveChanges();
            }
        }

        // 🟥 Delete user
        public void Delete(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}