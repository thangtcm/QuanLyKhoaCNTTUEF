using QuanLyKhoaCNTTUEF.Data;

namespace QuanLyKhoaCNTTUEF.Core.Repositories
{
    public interface IUserRepository
    {
        ICollection<ApplicationUser> GetUsers();

        ApplicationUser GetUser(string id);

        ApplicationUser UpdateUser(ApplicationUser user);
    }
}
