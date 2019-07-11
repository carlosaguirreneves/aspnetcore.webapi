using System.Threading.Tasks;
using AspnetCore.Domain;

namespace AspnetCore.Repository
{
    public interface IContatoRepository : IRepository<Contato>
    {
        Task<Contato> GetById(string id);
    }
}