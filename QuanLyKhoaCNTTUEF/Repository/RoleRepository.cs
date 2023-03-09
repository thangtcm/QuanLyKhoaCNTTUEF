using Microsoft.AspNetCore.Identity;
using QuanLyKhoaCNTTUEF.Core.Repositories;
using QuanLyKhoaCNTTUEF.Data;

namespace QuanLyKhoaCNTTUEF.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICollection<IdentityRole> GetRoles()
        {
            return _context.Roles.ToList();
        }
    }
}
