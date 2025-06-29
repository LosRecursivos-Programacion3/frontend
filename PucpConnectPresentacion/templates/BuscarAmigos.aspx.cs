using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PucpConnectDomain;
using PucpConnectPresentacion.PUCPConnectWS;

namespace PucpConnectPresentacion
{
    public partial class BuscarAmigos : System.Web.UI.Page
    {
        private UsuarioWSClient usuarioWSClient;
        protected void Page_Load(object sender, EventArgs e)
        {
            usuarioWSClient = new PUCPConnectWS.UsuarioWSClient();
            if (!IsPostBack)
            {
                CargarSugeridos();
            }
            string estado = Session["mensajeSolicitudEnviada"] as string;
            if (!string.IsNullOrEmpty(estado))
            {
                string script = "";
                if (estado == "ok")
                {
                    script = @"
                <script>
                    Swal.fire({
                        title: '¡Solicitud enviada!',
                        text: 'La solicitud de amistad fue enviada con éxito.',
                        icon: 'success'
                    });
                </script>";
                }
                else if (estado == "error")
                {
                    string detalle = Session["detalleError"]?.ToString() ?? "Error inesperado.";
                    script = $@"
                <script>
                    Swal.fire({{
                        title: 'Error',
                        text: '{detalle.Replace("'", "\\'")}',
                        icon: 'error'
                    }});
                </script>";
                }

                ClientScript.RegisterStartupScript(this.GetType(), "alertaSolicitud", script);

                // Limpiar las banderas
                Session.Remove("mensajeSolicitudEnviada");
                Session.Remove("detalleError");
            }
        }
        private void CargarSugeridos()
        {
            try
            {
                var usuarioActual = (alumno)Session["usuarioActual"];
                if (usuarioActual == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }
                var sugeridos = usuarioWSClient.listarSugeridos(usuarioActual.idAlumno);
                rptSugeridos.DataSource = sugeridos;
                rptSugeridos.DataBind();
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine("Error al cargar sugeridos: " + ex.Message);
            }
        }
        protected void btnSolicitar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idDestino = Convert.ToInt32(btn.CommandArgument);

            var usuarioActual = (alumno)Session["usuarioActual"];
            int idOrigen = usuarioActual.idAlumno;
            try
            {
                usuarioWSClient.enviarSolicitudAmistad(idOrigen, idDestino);

                // Guardar éxito en sesión
                Session["mensajeSolicitudEnviada"] = "ok";
            }
            catch (Exception ex)
            {
                // Guardar error en sesión
                Session["mensajeSolicitudEnviada"] = "error";
                Session["detalleError"] = ex.Message; // opcional, si quieres mostrarlo
            }

            // Redireccionar para evitar reenvío del formulario
            Response.Redirect(Request.RawUrl);
        }
    }
}