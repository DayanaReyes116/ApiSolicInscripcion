using ApiSolicInscripcion.Core.Entities;
using ApiSolicInscripcion.Core.Interfaces;
using ApiSolicInscripcion.Core.Interfaces.Repositories;
using ApiSolicInscripcion.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSolicInscripcion.Infrastructure.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;
        private readonly IUnitOfWork _unitOfWork;



        public LogService(ILogRepository logRepository, IUnitOfWork unitOfWork)
        {
            _logRepository = logRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task SaveAsync(Log log)
        {
            try
            {
                this._logRepository.Add(log);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception)
            {
            }
        }
    }
}
