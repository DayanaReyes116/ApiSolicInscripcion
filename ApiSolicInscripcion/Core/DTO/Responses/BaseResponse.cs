using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSolicInscripcion.Core.DTO.Responses
{
    public abstract class BaseResponse
    {
        public string title { get; protected set; }
        public int status { get; protected set; }

        public BaseResponse(string title, int status)
        {
            this.title = title;
            this.status = status;
        }

        public virtual bool IsSuccess()
        {
            return false;
        }
    }
}
