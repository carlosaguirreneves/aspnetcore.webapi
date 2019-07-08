using System.Threading.Tasks;

namespace Desafio.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T[]> FindAllPaginated(int page = 1, int size = 10);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> SaveChangesAsync();
    }
}