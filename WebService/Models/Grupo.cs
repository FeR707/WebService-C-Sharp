using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class Grupo
    {
        public int ID { get; set; }
        public string Nombre { get; set; }

        public virtual List<Alumno> Alumnos { get; set; }
    }

    public class GrupoDTO
    {
        public int ID { get; set; }
        public string Nombre { get; set; }

        public List<AlumnoDTO> Alumnos { get; set; }
    }
}