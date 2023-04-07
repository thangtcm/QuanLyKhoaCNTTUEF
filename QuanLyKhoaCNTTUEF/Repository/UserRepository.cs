using Microsoft.AspNetCore.Diagnostics;
using QuanLyKhoaCNTTUEF.Core.Repositories;
using QuanLyKhoaCNTTUEF.Data;

namespace QuanLyKhoaCNTTUEF.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICollection<ApplicationUser> GetUsers()
        {
            return _context.Users.ToList();
        }

        public ApplicationUser GetUser(string? id)
        {
            return _context.Users!.FirstOrDefault(u => u.Id == id);
        }

        public ApplicationUser UpdateUser(ApplicationUser user)
        {
            _context.Update(user);
            _context.SaveChanges();

            return user;
        }
    }
}
