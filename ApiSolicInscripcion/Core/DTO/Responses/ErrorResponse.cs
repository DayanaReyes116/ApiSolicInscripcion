using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSolicInscripcion.Core.DTO.Responses

{
    public class ErrorResponse: BaseResponse
    {
        public IEnumerable<Error> Errors { get; }

        public ErrorResponse(string title, int status, IEnumerable<Error> errors = null) : base(title, status)
        {
            if (errors == null)
            {
                errors = new List<Error>();
            }
            this.Errors = errors;
        }
    }
}