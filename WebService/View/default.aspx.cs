using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using HTTPupt;
using WebService.Models;
using WebService.Controllers;

namespace WebService.View
{
    public partial class _default : System.Web.UI.Page
    {
        PeticionHTTP peticion = new PeticionHTTP("http://localhost:54408");
        AlumnoController alumnoControl = new AlumnoController();
        Alumno nuevoAlumno = new Alumno();

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.RowDeleting += GridView1_RowDeleting;
            CargarDatos();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            nuevoAlumno.Nombre = txtNombre.Text;
            alumnoControl.Create(nuevoAlumno);
            CargarDatos();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[rowIndex];

                int id = Convert.ToInt32(row.Cells[0].Text); // Obtener el valor de la celda "ID"
                string nombre = row.Cells[1].Text; // Obtener el valor de la celda "Nombre"

            }
        }

        private void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Obtener el ID del alumno a eliminar
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text); // Obtener el valor de la celda "ID"

            // Eliminar el alumno de la base de datos
            Alumno alumno = new Alumno
            {
                ID = id
            };
            string enviarJson = JsonConvertidor.Objeto_Json(alumno);
            peticion.PedirComunicacion("Alumno/Delete", MetodoHTTP.DELETE, TipoContenido.JSON);
            peticion.enviarDatos(enviarJson);
            string json = peticion.ObtenerJson();

            CargarDatos();
        }

        private void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            CargarDatos();
        }

        private void CargarDatos()
        {
            peticion.PedirComunicacion("Alumno/Read", MetodoHTTP.GET, TipoContenido.JSON);
            string respuesta = peticion.ObtenerJson();
            List<AlumnoDTO> alumnos = JsonConvertidor.Json_ListaObjeto<AlumnoDTO>(respuesta);
            GridView1.DataSource = alumnos;
            GridView1.DataBind();
        }
    }
}