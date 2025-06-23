using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PucpConnectPresentacion.PUCPConnectWS;

namespace PucpConnectPresentacion
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var usuarioActual = (usuario)Session["usuarioActual"];
            if (usuarioActual == null)
            {
                lblNombrePerfil.Text = "NO EN SESIÓN"; // DEBUG: Para saber si no hay sesión
                return;
            }

            lblNombrePerfil.Text = usuarioActual.nombre;
        }

        protected void btnConfigurar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProfileModify.aspx");
        }

        protected void btnConfigureInterests_Click(object sender, EventArgs e) {
            Response.Redirect("InteresModify.aspx");
        }
    }
}