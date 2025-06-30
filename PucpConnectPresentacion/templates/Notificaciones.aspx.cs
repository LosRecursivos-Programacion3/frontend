using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using PucpConnectPresentacion.PUCPConnectWS;
using PucpConnectPresentacion.NotificacionWS;
namespace PucpConnectPresentacion.templates
{
    public partial class Notificaciones : Page
    {
        private NotificacionWSClient notiWS;

        protected void Page_Load(object sender, EventArgs e)
        {
            notiWS = new NotificacionWSClient();

            var usuario = Session["usuarioActual"] as alumno;
            if (usuario == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                CargarNotificaciones(usuario.id);
            }
        }

        private void CargarNotificaciones(int idUsuario)
        {
            try
            {
                var lista = notiWS.obtenerNotificaciones(idUsuario);
                rptNotifs.DataSource = lista;
                rptNotifs.DataBind();
                lblMensaje.Text = "";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al cargar: " + ex.Message;
            }
        }

        protected void lnkMarcar_Command(object sender, CommandEventArgs e)
        {
            int idNotif = Convert.ToInt32(e.CommandArgument);
            try
            {
                notiWS.marcarComoVisto(idNotif);

                // Vuelva a cargar, usando el mismo usuario de sesión
                var usuario = ((alumno)Session["usuarioActual"]).id;
                CargarNotificaciones(usuario);
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "No se pudo marcar: " + ex.Message;
            }
        }
    }
}
