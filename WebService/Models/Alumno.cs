﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class Alumno
    {
        public int ID { get; set; }
        public string Nombre { get; set; }

        public int GrupoID { get; set; }
        public virtual Grupo Grupo { get; set; }
    }

    public class AlumnoDTO
    {
        public int ID { get; set; }
        public string Nombre { get; set; }

        public int GrupoID { get; set; }
        public string Grupo { get; set; }
    }
}