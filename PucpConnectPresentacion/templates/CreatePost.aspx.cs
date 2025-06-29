using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PucpConnectPresentacion.PUCPConnectWS;

namespace PucpConnectPresentacion.templates
{
    public partial class CreatePost : System.Web.UI.Page
    {
        private UsuarioWSClient usuarioWSClient;
        protected void Page_Load(object sender, EventArgs e)
        {
            usuarioWSClient = new PUCPConnectWS.UsuarioWSClient();
            var usuarioActual = (alumno)Session["usuarioActual"];
            if (usuarioActual == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            // Contenido de la publicación
            string contenido = txtContenido.Text.Trim();

            // Nombre del archivo (si se subió uno)
            string nombreArchivo = null;
            if (fuImagen.HasFile)
            {
                nombreArchivo = Path.GetFileName(fuImagen.FileName);
                // Opcionalmente, guardar en servidor (si lo necesitas después)
                // string ruta = Server.MapPath("~/Multimedia/" + nombreArchivo);
                // fuImagen.SaveAs(ruta);
            }
            var usuarioActual = (alumno)Session["usuarioActual"];

            try
            {
                usuarioWSClient.crearPost(contenido, nombreArchivo, usuarioActual.id);
                Response.Redirect("Main.aspx");
            }
            catch (Exception ex)
            {
                LblMensaje.Text = "Error: " + ex.Message;
            }
            // Aquí va la llamada a tu WS con esos datos
        }
    }

}