using System.Threading.Tasks;
using Desafio.Domain;

namespace Desafio.Repository
{
    public interface IUserRepository : IRepository<User>
    {
         Task<User> FindByUserName(string userName);
    }
}