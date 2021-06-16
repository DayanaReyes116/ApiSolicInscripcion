using System.Threading.Tasks;
using ApiSolicInscripcion.Core.Entities;

namespace ApiSolicInscripcion.Core.Interfaces.Services
{
    public interface ILogService
    {
       Task SaveAsync(Log log);
    }
}

