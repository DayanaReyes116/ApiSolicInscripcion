
using ApiSolicInscripcion.Core.Entities;
using ApiSolicInscripcion.Core.Interfaces.Repositories;
using ApiSolicInscripcion.Core.Models;

namespace ApiSolicInscripcion.Infrastructure.Data.Repositories
{
    public class SolicitudRepository : BaseRepository<Solicitudes>, ISolicitudRepository
    {
        public SolicitudRepository(SolicitudDbContext context) : base(context)
        {
        }
    }
}
