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
    public class GrupoController : ApiController
    {
        Model1 BD = new Model1();

        [ActionName("ConsultaAlumnoGrupo")]
        [HttpGet]

        public IQueryable<GrupoDTO> ConsultaAlumnoGrupo(int id)
        {
            var alumnos = from Grupo in BD.Grupo
                          where Grupo.ID == id
                          select new GrupoDTO
                          {
                              ID = Grupo.ID,
                              Nombre = Grupo.Nombre,
                              Alumnos = Grupo.Alumnos.Select(c => new AlumnoDTO
                              {
                                  ID = c.ID,
                                  Nombre = c.Nombre
                              }).ToList()
                          };
            return alumnos;
        }

        [ActionName("Create")]
        [HttpPost]
        public bool Create(Grupo grupo)
        {
            try
            {
                BD.Grupo.Add(grupo);
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
        public IQueryable<GrupoDTO> Read()
        {
            try
            {
                var grupos = from alumno in BD.Grupo
                             select new GrupoDTO
                             {
                                 ID = alumno.ID,
                                 Nombre = alumno.Nombre
                             };
                return grupos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los registros de grupos.", ex);
            }
        }

        [ActionName("Update")]
        [HttpPut]
        public bool Update(Grupo grupo)
        {
            try
            {
                var consulta = BD.Grupo.Where(c => c.ID == grupo.ID).FirstOrDefault();

                consulta.Nombre = grupo.Nombre;

                BD.Grupo.AddOrUpdate(consulta);
                BD.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [ActionName("Delete")]
        [HttpDelete]
        public bool Delete(int id)
        {
            try
            {
                var consulta = BD.Grupo.Where(c => c.ID == id).FirstOrDefault();

                BD.Grupo.Remove(consulta);
                BD.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
