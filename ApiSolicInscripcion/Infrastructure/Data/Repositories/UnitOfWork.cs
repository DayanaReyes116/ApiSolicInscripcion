
using ApiSolicInscripcion.Core.Interfaces;
using ApiSolicInscripcion.Core.Models;
using System.Threading.Tasks;

namespace ApiSolicInscripcion.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SolicitudDbContext _context;

        public UnitOfWork(SolicitudDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
