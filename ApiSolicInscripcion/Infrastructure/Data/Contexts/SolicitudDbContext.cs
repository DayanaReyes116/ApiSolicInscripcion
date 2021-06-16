using ApiSolicInscripcion.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiSolicInscripcion.Core.Models
{
    public class SolicitudDbContext : DbContext
    {
        public DbSet<Solicitudes> Solicitud { get; set; }
        public SolicitudDbContext() {  }
        public SolicitudDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
