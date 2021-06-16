using ApiSolicInscripcion.Core.Entities;
using ApiSolicInscripcion.Core.Interfaces.Repositories;
using ApiSolicInscripcion.Core.Models;


namespace ApiSolicInscripcion.Infrastructure.Data.Repositories
{
    public class LogRepository : BaseRepository<Log>, ILogRepository
    {
        public LogRepository(SolicitudDbContext context) : base(context)
        {
        }
    }
}

