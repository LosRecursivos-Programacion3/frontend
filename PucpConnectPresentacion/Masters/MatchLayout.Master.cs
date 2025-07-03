using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PucpConnectPresentacion.PUCPConnectWS;
namespace PucpConnectPresentacion.Masters
{
    public partial class MatchLayout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var usuarioActual = (alumno)Session["usuarioActual"];
            if (usuarioActual == null)
            {
                Response.Redirect("Login.aspx?returnUrl=" + Server.UrlEncode(Request.RawUrl));
                return;
            }

            lblNombreUsuario.Text = usuarioActual.nombre;
            imgPerfil.ImageUrl = string.IsNullOrEmpty(usuarioActual.fotoPerfil)
                ? "../Images/blank-profile.png"
                : $"../Images/{usuarioActual.fotoPerfil}";
        }
    }
}