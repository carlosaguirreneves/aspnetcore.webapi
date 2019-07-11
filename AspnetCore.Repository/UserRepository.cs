using System.Threading.Tasks;
using AspnetCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace AspnetCore.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public DataContext _context { get; }

        public UserRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> FindByUserName(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
        }
    }
}