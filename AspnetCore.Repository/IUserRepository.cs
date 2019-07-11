using System.Threading.Tasks;
using AspnetCore.Domain;

namespace AspnetCore.Repository
{
    public interface IUserRepository : IRepository<User>
    {
         Task<User> FindByUserName(string userName);
    }
}