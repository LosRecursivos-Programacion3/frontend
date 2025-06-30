using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PucpConnectPresentacion.PucpConnectWS;

namespace PucpConnectPresentacion
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var usuarioActual = (alumno)Session["usuarioActual"];
            if (usuarioActual == null)
            {
                lblNombrePerfil.Text = "NO EN SESIÓN"; // DEBUG: Para saber si no hay sesión
                return;
            }

            lblNombrePerfil.Text = usuarioActual.nombre;
            lblCarrera.Text = usuarioActual.carrera;       
            lblBiografia.Text = usuarioActual.biografia; 
        }

        protected void btnConfigurar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProfileModify.aspx");
        }

        protected void btnConfigureInterests_Click(object sender, EventArgs e) {
            Response.Redirect("SelectInterest.aspx");
        }
    }
}