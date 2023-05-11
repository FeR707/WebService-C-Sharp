using HTTPupt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebService.Models;

namespace WebService.View
{
    public partial class GrupoDatos : System.Web.UI.Page
    {
        PeticionHTTP peticion = new PeticionHTTP("http://localhost:54408");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/default.aspx");
        }

        protected void BtnCreateGrupo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtGrupoNombre.Text))
            {
                string mensaje = "Ingrese Nombre del grupo";
                string script = "alert('" + mensaje + "');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
            }
            else
            {
                Grupo grupo = new Grupo
                {
                    Nombre = txtGrupoNombre.Text
                };

                string enviarJson = JsonConvertidor.Objeto_Json(grupo);
                peticion.PedirComunicacion("Grupo/Create", MetodoHTTP.POST, TipoContenido.JSON);
                peticion.enviarDatos(enviarJson);
                string json = peticion.ObtenerJson();
                Response.Redirect("~/View/default.aspx");
            }
        }
    }
}