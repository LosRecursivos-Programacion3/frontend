using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PucpConnectPresentacion.PUCPConnectWS;

namespace PucpConnectPresentacion
{
    public partial class Main : System.Web.UI.Page
    {
        private UsuarioWSClient usuarioWSClient;
        protected void Page_Load(object sender, EventArgs e)
        {
            usuarioWSClient = new PUCPConnectWS.UsuarioWSClient();
            if (!IsPostBack)
            {
                CargarPublicacionesFeed();
            }
        }

        private void CargarPublicacionesFeed()
        {
            var usuarioActual = (alumno)Session["usuarioActual"];
            if(usuarioActual == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }
            var publicaciones = usuarioWSClient.listarPostParaMain(usuarioActual.idAlumno);

            if (publicaciones == null || publicaciones.Length == 0)
            {
                lblSinPublicaciones.Visible = true;
                rptMainFeed.Visible = false;
                return;
            }

            var publicacionesVisual = publicaciones.Select(p => new
            {
                Contenido = p.contenido,
                ImagenPost = string.IsNullOrEmpty(p.imagen) ? null : $"../Images/{p.imagen}",
                FechaPublicacion = p.fecha, // ya está formateada como string en el backend
                NombreAutor = p.nombreAutor,
                CarreraAutor = p.carreraAutor,
                RutaFotoPerfil = $"../Images/{(string.IsNullOrEmpty(p.fotoAutor) ? "default.jpg" : p.fotoAutor)}"
            }).ToList();

            rptMainFeed.DataSource = publicacionesVisual;
            rptMainFeed.DataBind();
        }
    }
}