using ApiSolicInscripcion.Core.DTO.Responses;
using ApiSolicInscripcion.Core.Entities;
using ApiSolicInscripcion.Core.Interfaces;
using ApiSolicInscripcion.Core.Interfaces.Repositories;
using ApiSolicInscripcion.Core.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiSolicInscripcion.Infrastructure.Services
{
    public class SolicitudService : ISolicitudService
    {
        private readonly ISolicitudRepository _solicitudRepository;
        private readonly IUnitOfWork _unitOfWork;


        public SolicitudService(ISolicitudRepository solicitudRepository, IUnitOfWork unitOfWork)
        {
            _solicitudRepository = solicitudRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Solicitudes>> FindAllAsync()
        {
            return await this._solicitudRepository.FindAll().ToListAsync();
        }

        public async Task<BaseResponse> SaveAsync(Solicitudes solicitud)
        {
            try
            {
                this._solicitudRepository.Add(solicitud);
                await _unitOfWork.CompleteAsync();

                return new SuccessResponse("Solicitud creado", solicitud);
            }
            catch (Exception e)
            {
                return new ErrorResponse(e.Message, 400);
            }
        }

        public async Task<BaseResponse> UpdateAsync(int id, Solicitudes solicitud)
        {
            var result = this._solicitudRepository.FindById(id);
            if (result == null)
            {
                return new ErrorResponse($"No existe la solicitud con el id {id}", 404);
            }

            result.sName = solicitud.sName;
            result.sApellido = solicitud.sApellido;
            result.iIdentificacion = solicitud.iIdentificacion;
            result.iEdad = solicitud.iEdad;
            result.iIdCasa = solicitud.iIdCasa;

            this._solicitudRepository.Update(result);
            await _unitOfWork.CompleteAsync();

            return new SuccessResponse("Solicitud actualizada", result);
        }

        public async Task<BaseResponse> DeleteAsync(int id)
        {
            var result = this._solicitudRepository.FindById(id);
            if (result == null)
            {
                return new ErrorResponse($"No existe la solicitud con el id {id}", 404);
            }

            this._solicitudRepository.Delete(result);
            await _unitOfWork.CompleteAsync();

            return new SuccessResponse("Solicitud eliminado", result);
        }
    }
}



