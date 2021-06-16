using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSolicInscripcion.Core.Interfaces
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
