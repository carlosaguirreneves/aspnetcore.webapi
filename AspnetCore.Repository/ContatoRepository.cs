using System.Threading.Tasks;
using AspnetCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace AspnetCore.Repository
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