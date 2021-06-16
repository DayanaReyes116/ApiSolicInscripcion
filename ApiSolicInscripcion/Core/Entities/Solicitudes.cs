using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSolicInscripcion.Core.Entities
{
    public class Solicitudes : BaseEntity
    {
        [Key]
        public int iId { get; set; }

        [Required(ErrorMessage = "Name es Requerido!")]
        [StringLength(20)]
        public string sName { get; set; }

        [Required(ErrorMessage = "Apellido es Requerido!")]
        [StringLength(20)]
        public string sApellido { get; set; }

        public int iIdentificacion { get; set; }

        public int iEdad { get; set; }

        [Required(ErrorMessage = "No existe la casa.")]
        public int iIdCasa { get; set; }
        public string sNameCasa { get; set; }
    }
}
