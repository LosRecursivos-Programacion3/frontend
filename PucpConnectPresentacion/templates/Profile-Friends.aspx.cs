using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PucpConnectPresentacion.PUCPConnectWS;
namespace PucpConnectPresentacion.templates
{
    public partial class Profile_Friends : System.Web.UI.Page
    {
        private UsuarioWSClient usuarioWSClient;
        protected void Page_Load(object sender, EventArgs e)
        {
            usuarioWSClient = new PUCPConnectWS.UsuarioWSClient();
            var usuarioActual = (alumno)Session["usuarioActual"];
            if (usuarioActual == null)
            {
                lblNombrePerfil.Text = "NO EN SESIÓN"; // DEBUG: Para saber si no hay sesión
                return;
            }

            lblNombrePerfil.Text = usuarioActual.nombre;
            lblCarrera.Text = usuarioActual.carrera;
            lblBiografia.Text = usuarioActual.biografia;
            // Asignar imagen de perfil dinámica
            string nombreArchivo = usuarioActual.fotoPerfil;
            if (!string.IsNullOrEmpty(nombreArchivo))
            {
                imgPerfil.ImageUrl = "../Images/" + nombreArchivo;
            }
            else
            {
                imgPerfil.ImageUrl = "../Images/profile-0.jpg"; // Imagen por defecto
            }

            var amigos = usuarioWSClient.listarAmigosPorId(usuarioActual.idAlumno);
            rptAmigos.DataSource = amigos;
            rptAmigos.DataBind();
        }

        protected void btnConfigurar_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditProfile.aspx");
        }

        protected void btnConfigureInterests_Click(object sender, EventArgs e)
        {
            Response.Redirect("SelectInterest.aspx");
        }
    }
}