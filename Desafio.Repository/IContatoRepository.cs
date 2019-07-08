using System.Threading.Tasks;
using Desafio.Domain;

namespace Desafio.Repository
{
    public interface IContatoRepository : IRepository<Contato>
    {
        Task<Contato> GetById(string id);
    }
}