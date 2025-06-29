using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PucpConnectPresentacion.PUCPConnectWS;
namespace PucpConnectPresentacion.templates
{
    public partial class FriendRequests : System.Web.UI.Page
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
            string nombreArchivo = usuarioActual.fotoPerfil;
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
                CargarSolicitudes();
            }
        }
        private void CargarSolicitudes()
        {
            alumno usuarioActual = (alumno)Session["usuarioActual"];
            if (usuarioActual == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            int idAlumno = usuarioActual.idAlumno;

            var enviadas = usuarioWSClient.listarSolicitudesEnviadas(idAlumno);
            var recibidas = usuarioWSClient.listarSolicitudesRecibidas(idAlumno);

            // Enviadas
            if (enviadas != null && enviadas.Count() > 0)
            {
                gvSolicitudesEnviadas.Visible = true;
                lblSinSolicitudesEnviadas.Visible = false;
                gvSolicitudesEnviadas.DataSource = enviadas;
                gvSolicitudesEnviadas.DataBind();
            }
            else
            {
                gvSolicitudesEnviadas.Visible = false;
                lblSinSolicitudesEnviadas.Visible = true;
            }

            // Recibidas
            if (recibidas != null && recibidas.Count() > 0)
            {
                gvSolicitudesRecibidas.Visible = true;
                lblSinSolicitudesRecibidas.Visible = false;
                gvSolicitudesRecibidas.DataSource = recibidas;
                gvSolicitudesRecibidas.DataBind();
            }
            else
            {
                gvSolicitudesRecibidas.Visible = false;
                lblSinSolicitudesRecibidas.Visible = true;
            }
        }

        protected void gvSolicitudesEnviadas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Cancelar")
            {
                int idAmistad = Convert.ToInt32(e.CommandArgument);
                try
                {
                    usuarioWSClient.cancelarSolicitud(idAmistad);
                    CargarSolicitudes();
                }
                catch (Exception ex)
                {
                    // Manejo de error: puedes mostrar un mensaje con SweetAlert si quieres
                    Console.WriteLine("Error al cancelar solicitud: " + ex.Message);
                }
            }
        }

        protected void gvSolicitudesRecibidas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idAmistad = Convert.ToInt32(e.CommandArgument);

            try
            {
                if (e.CommandName == "Aceptar")
                {
                    usuarioWSClient.aceptarSolicitud(idAmistad);
                }
                else if (e.CommandName == "Rechazar")
                {
                    usuarioWSClient.rechazarSolicitud(idAmistad);
                }

                CargarSolicitudes();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al procesar solicitud recibida: " + ex.Message);
            }
        }
    }
}