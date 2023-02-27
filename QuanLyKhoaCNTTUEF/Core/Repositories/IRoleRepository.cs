using Microsoft.AspNetCore.Identity;

namespace QuanLyKhoaCNTTUEF.Core.Repositories
{
    public interface IRoleRepository
    {
        ICollection<IdentityRole> GetRoles();
    }
}
