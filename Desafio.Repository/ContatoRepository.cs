using System.Threading.Tasks;
using Desafio.Domain;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Repository
{
    public class ContatoRepository : Repository<Contato>, IContatoRepository
    {
        private DataContext _context { get; }
        
        public ContatoRepository(DataContext context) : base(context)
        {
            _context = context;
        }
        
        public async Task<Contato> GetById(string id)
        {
            return await _context.Contatos.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}