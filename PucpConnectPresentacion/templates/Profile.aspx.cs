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
            string nombreArchivo = usuarioActual.fotoPerfil; // Ejemplo: "foto123.jpg"
            if (!string.IsNullOrEmpty(nombreArchivo))
            {
                imgPerfil.ImageUrl = "../Images/" + nombreArchivo;
            }
            else
            {
                imgPerfil.ImageUrl = "../Images/profile-0.jpg"; // Imagen por defecto
            }

            if (!IsPostBack)
            {
                CargarPublicaciones(usuarioActual.idAlumno);
            }
        }

        private void CargarPublicaciones(int idAlumno)
        {
            var publicaciones = usuarioWSClient.listarPostPorId(idAlumno);
            var usuarioActual = (alumno)Session["usuarioActual"];
            // Convertir a un DTO visual si es necesario
            if (publicaciones != null && publicaciones.Any())
            {
                var publicacionesVisual = publicaciones.Select(p => new
                {
                    Contenido = p.contenido,
                    ImagenPost = string.IsNullOrEmpty(p.imagen) ? null : $"../Images/{p.imagen}",
                    RutaImagenAutor = $"../Images/{usuarioActual.fotoPerfil}",
                    NombreAutor = usuarioActual.nombre,
                    CarreraYFecha = $"{usuarioActual.carrera} · {p.fecha}"
                }).ToList();

                // Mostrar publicaciones en pantalla
            }
            else
            {
                lblSinPublicaciones.Visible = true;
            }

        }

        protected void btnConfigurar_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditProfile.aspx");
        }

        protected void btnConfigureInterests_Click(object sender, EventArgs e) {
            Response.Redirect("SelectInterest.aspx");
        }
    }
}