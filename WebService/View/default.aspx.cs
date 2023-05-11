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
using System.Security.Cryptography;

namespace WebService.View
{
    public partial class _default : System.Web.UI.Page
    {
        PeticionHTTP peticion = new PeticionHTTP("http://localhost:54408");

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Datos.aspx?op=C");
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            string id;
            Button Consulta = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)Consulta.NamingContainer;
            id = selectedrow.Cells[0].Text;
            Response.Redirect("~/View/Datos.aspx?id=" + id + "&op=U");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string id;
            Button Consulta = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)Consulta.NamingContainer;
            id = selectedrow.Cells[0].Text;
            Response.Redirect("~/View/Datos.aspx?id=" + id + "&op=D");
        }

        private void CargarDatos()
        {
            peticion.PedirComunicacion("Alumno/ConsultarAlumnoGrupo", MetodoHTTP.GET, TipoContenido.JSON);
            string respuesta = peticion.ObtenerJson();
            List<AlumnoDTO> alumnos = JsonConvertidor.Json_ListaObjeto<AlumnoDTO>(respuesta);
            GridView1.DataSource = alumnos;
            GridView1.DataBind();
        }

        protected void BtnGrupo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/GrupoDatos.aspx");
        }
    }
}