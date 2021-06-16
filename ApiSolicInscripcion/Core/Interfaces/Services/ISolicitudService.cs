using ApiSolicInscripcion.Core.DTO.Responses;
using ApiSolicInscripcion.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiSolicInscripcion.Core.Interfaces.Services
{
    public interface ISolicitudService
    {
        Task<IEnumerable<Solicitudes>> FindAllAsync();

        Task<BaseResponse> SaveAsync(Solicitudes solicitud);

        Task<BaseResponse> UpdateAsync(int id, Solicitudes solicitud);

        Task<BaseResponse> DeleteAsync(int id);
    }
}
