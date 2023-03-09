using QuanLyKhoaCNTTUEF.Core.Repositories;

namespace QuanLyKhoaCNTTUEF.Repositories
{
    public class UnitOfWorks : IUnitOfWork
    {
        public IUserRepository User { get; }
        public IRoleRepository Role { get; }

        public UnitOfWorks(IUserRepository user, IRoleRepository role)
        {
            User = user;
            Role = role;
        }
    }
}
