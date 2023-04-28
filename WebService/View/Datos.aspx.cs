using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HTTPupt;
using WebService.Controllers;
using WebService.Models;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace WebService.View
{
    public partial class Datos : System.Web.UI.Page
    {
        PeticionHTTP peticion = new PeticionHTTP("http://localhost:54408");
        AlumnoController alumnoControl = new AlumnoController();
        Alumno nuevoAlumno = new Alumno();

        public static string sID = "-1";
        public static string sOpc = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            //obtener el id
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    sID = Request.QueryString["id"].ToString();
                    CargarDatos();
                }

                if (Request.QueryString["op"] != null)
                {
                    sOpc = Request.QueryString["op"].ToString();

                    switch (sOpc)
                    {
                        case "C":
                            this.lbltitulo.Text = "Ingresar nuevo usuario";
                            this.BtnCreate.Visible = true;
                            break;
                        case "R":
                            break;
                        case "U":
                            this.lbltitulo.Text = "Modificar usuario";
                            this.BtnUpdate.Visible = true;
                            break;
                        case "D":
                            this.lbltitulo.Text = "Eliminar usuario";
                            this.BtnDelete.Visible = true;
                            this.txtNombre.ReadOnly = true;
                            break;
                    }
                }
            }
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                // El campo está vacío, mostrar una alerta
                string mensaje = "Por favor ingrese un nombre";
                string script = "alert('" + mensaje + "');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
            }
            else
            {
                nuevoAlumno.Nombre = txtNombre.Text;
                alumnoControl.Create(nuevoAlumno);
                Response.Redirect("~/View/default.aspx");
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            Alumno alumno = new Alumno
            {
                // Actualizar el alumno en la base de datos
                ID = Convert.ToInt32(sID),
                Nombre = txtNombre.Text
            };

            string enviarJson = JsonConvertidor.Objeto_Json(alumno);
            peticion.PedirComunicacion("Alumno/Update", MetodoHTTP.PUT, TipoContenido.JSON);
            peticion.enviarDatos(enviarJson);
            string json = peticion.ObtenerJson();

            Response.Redirect("~/View/default.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            // Eliminar el alumno de la base de datos
            Alumno alumno = new Alumno
            {
                ID = Convert.ToInt32(sID)
            };

            string enviarJson = JsonConvertidor.Objeto_Json(alumno);
            peticion.PedirComunicacion("Alumno/Delete", MetodoHTTP.DELETE, TipoContenido.JSON);
            peticion.enviarDatos(enviarJson);
            string json = peticion.ObtenerJson();

            Response.Redirect("~/View/default.aspx");
        }

        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/default.aspx");
        }

        public void CargarDatos()
        {
            peticion.PedirComunicacion("Alumno/Busqueda/" + Convert.ToInt32(sID), MetodoHTTP.GET, TipoContenido.JSON);
            string respuesta = peticion.ObtenerJson();
            List<AlumnoDTO> alumnos = JsonConvertidor.Json_ListaObjeto<AlumnoDTO>(respuesta);

            if (sID != "-1")
            {
                txtNombre.Text = alumnos.Where(x => x.ID == Convert.ToInt32(sID)).FirstOrDefault().Nombre;
            }
        }
    }
}