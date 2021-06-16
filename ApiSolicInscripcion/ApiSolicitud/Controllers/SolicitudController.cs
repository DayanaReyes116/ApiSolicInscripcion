using ApiSolicInscripcion.Core.DTO.Responses;
using ApiSolicInscripcion.Core.Entities;
using ApiSolicInscripcion.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiSolicInscripcion.ApiSolicitud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class SolicitudController : Controller
    {
        private readonly ISolicitudService _solicitudService;
        public SolicitudController(ISolicitudService solicitudService)
        {
            _solicitudService = solicitudService;
        }

        ///<summary>
        ///GET: Consultar todas las solicitudes enviadas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IEnumerable<Solicitudes>> ListAsync()
        {
            /*
            var result = await _solicitudService.FindAllAsync();
            return result;*/

            var result = await _solicitudService.FindAllAsync();
            Solicitudes resSolicitud = null;
            List<Solicitudes> listSolicitud = new List<Solicitudes>();

            foreach (Solicitudes item in result)
            {
                if (item.iIdCasa == 1)
                {
                    item.sNameCasa = "Gryffindor";
                }
                else if (item.iIdCasa == 2)
                {
                    item.sNameCasa = "Hufflepuff";
                }
                else if (item.iIdCasa == 3)
                {
                    item.sNameCasa = "Ravenclaw";
                }
                else
                {
                    item.sNameCasa = "Slytherin";
                }


                resSolicitud = item;
                listSolicitud.Add(resSolicitud);
            }

            return listSolicitud;


        }
       
        /// <summary>
        /// POST api : Método Enviar Solicitud de Ingreso
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PostAsync([FromBody] Solicitudes solicitud)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _solicitudService.SaveAsync(solicitud);

            return StatusCode(result.status, result);
        }

        /// <summary>
        /// PUT api/ : Actualizar solicitud de Ingreso
        /// </summary>
        /// <param name="id"></param>
        /// /// <param name="solicitud"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Solicitudes solicitud)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _solicitudService.UpdateAsync(id, solicitud);

            if (!result.IsSuccess())
            {
                var errResponse = result as ErrorResponse;
                if (errResponse.status == 404)
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest(errResponse);
                }
            }

            return Ok((result as SuccessResponse).Data);
        }

        /// <summary>
        /// DELETE api/ : Eliminar la solicitud de ingreso
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _solicitudService.DeleteAsync(id);

            if (!result.IsSuccess())
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
