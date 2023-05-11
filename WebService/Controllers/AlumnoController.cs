using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebService.Models;

namespace WebService.Controllers
{
    public class AlumnoController : ApiController
    {
        Model1 BD = new Model1();

        [ActionName("Create")]
        [HttpPost]
        public bool Create(Alumno alumno)
        {
            try
            {
                BD.Alumno.Add(alumno);
                BD.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [ActionName("Read")]
        [HttpGet]
        public IQueryable<AlumnoDTO> Read()
        {
            try
            {
                var alumnos = from alumno in BD.Alumno
                              select new AlumnoDTO
                              {
                                  ID = alumno.ID,
                                  Nombre = alumno.Nombre,
                                  GrupoID = alumno.GrupoID,
                              };
                return alumnos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los registros de alumnos.", ex);
            }
        }

        [ActionName("ConsultarAlumnoGrupo")]
        [HttpGet]
        public IQueryable<AlumnoDTO> ConsultarAlumnoGrupo()
        {
            var alumnos = from Alumno in BD.Alumno
                          select new AlumnoDTO
                          {
                              ID = Alumno.ID,
                              Nombre = Alumno.Nombre,
                              GrupoID = Alumno.GrupoID,
                              Grupo = Alumno.Grupo.Nombre
                          };
            return alumnos;
        }

        [ActionName("Update")]
        [HttpPut]
        public bool Update(Alumno alumno)
        {
            try
            {
                var consulta = BD.Alumno.Where(c => c.ID == alumno.ID).FirstOrDefault();

                if (consulta != null)
                {
                    consulta.Nombre = alumno.Nombre;
                    consulta.GrupoID = alumno.GrupoID;
                    BD.Alumno.AddOrUpdate(consulta);
                    BD.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [ActionName("Delete")]
        [HttpDelete]
        public bool Delete(Alumno alumno)
        {
            try
            {
                var consulta = BD.Alumno.Where(c => c.ID == alumno.ID).FirstOrDefault();

                if (consulta != null)
                {
                    BD.Alumno.Remove(consulta);
                    BD.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
