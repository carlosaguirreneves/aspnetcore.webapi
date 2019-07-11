using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AspnetCore.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DataContext _context { get; }

        public Repository(DataContext context)
        {
            _context = context;
        }

        public async Task<T[]> FindAllPaginated(int page = 1, int size = 10)
        {
            var skip = (page - 1) * size;
            return await _context.Set<T>()
                .Skip(skip).Take(size).ToArrayAsync();
        }

        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}