using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSolicInscripcion.Core.Entities
{
    public class Casas
    {
        [Key]
        public int iId { get; set; }
        public string sDescripcion { get; set; }
    }
}
