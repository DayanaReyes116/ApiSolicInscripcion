using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSolicInscripcion.Core.DTO.Responses
{
    public class SuccessResponse : BaseResponse
    {
        public dynamic Data { get; protected set; }

        public SuccessResponse(string title, dynamic data, int status = 200) : base(title, status)
        {
            this.Data = data;
        }

        public override bool IsSuccess()
        {
            return true;
        }
    }
}