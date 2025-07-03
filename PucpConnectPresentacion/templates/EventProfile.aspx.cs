using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.UI;
using PucpConnectPresentacion.EventoWS;
using PucpConnectPresentacion.InteresWS;

namespace PucpConnectPresentacion.templates
{
    public partial class EventProfile : System.Web.UI.Page
    {
        private readonly EventoWSClient eventoService = new EventoWSClient();
        private int idEvento;
        private int idUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!ObtenerUsuarioActual(out idUsuario))
                {
                    Response.Redirect("~/Login.aspx?error=" + Server.UrlEncode("Debe iniciar sesión para participar en eventos"));
                    return;
                }

                if (!int.TryParse(Request.QueryString["id"], out idEvento))
                {
                    Response.Redirect("~/templates/Events.aspx");
                    return;
                }

                ViewState["EventoId"] = idEvento;
                ViewState["UsuarioId"] = idUsuario;

                CargarDatosEvento(idEvento);
                CargarParticipantes(idEvento);
                VerificarAsistenciaUsuario(idEvento, idUsuario);
            }
        }

        protected void btnCancelarAsistencia_Click(object sender, EventArgs e)
        {
            try
            {
                int eventoId = (int)ViewState["EventoId"];
                int usuarioId = (int)ViewState["UsuarioId"];

                bool exito = eventoService.cancelarParticipacionEvento(eventoId, usuarioId);

                if (exito)
                {
                    MostrarExito("¡Asistencia cancelada con éxito!");
                    btnAsistir.Visible = true;
                    btnCancelarAsistencia.Visible = false;

                    // Forzar recarga de datos
                    CargarDatosEvento(eventoId);
                    CargarParticipantes(eventoId);
                    ActualizarContadorParticipantes();
                }
                else
                {
                    MostrarError("No se pudo cancelar la asistencia");
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al cancelar asistencia: " + ex.Message);
            }
        }

        protected void btnConfirmarCancelacion_Click(object sender, EventArgs e)
        {
            try
            {
                // Recuperar IDs desde ViewState
                int eventoId = (int)ViewState["EventoId"];
                int usuarioId = (int)ViewState["UsuarioId"];
               

                bool exito = eventoService.cancelarParticipacionEvento(eventoId, usuarioId);

                if (exito)
                {
                    MostrarExito("¡Asistencia cancelada con éxito!");
                    btnAsistir.Visible = true;
                    btnCancelarAsistencia.Visible = false;
                    CargarParticipantes(eventoId);
                    ActualizarContadorParticipantes();

                    // Cerrar modal
                    ScriptManager.RegisterStartupScript(this, GetType(), "HideCancelModal",
                        "$('#confirmCancelModal').modal('hide');", true);
                }
                else
                {
                    MostrarError("No se pudo cancelar la asistencia");
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al cancelar asistencia: " + ex.Message);
            }
        }

        protected void btnAsistir_Click(object sender, EventArgs e)
        {
            try
            {
                int eventoId = (int)ViewState["EventoId"];
                int usuarioId = (int)ViewState["UsuarioId"];

                bool exito = eventoService.registrarParticipacionEvento(eventoId, usuarioId);

                if (exito)
                {
                    MostrarExito("¡Asistencia confirmada con éxito!");
                    btnAsistir.Visible = false;
                    btnCancelarAsistencia.Visible = true;

                    // Forzar recarga de datos
                    CargarDatosEvento(eventoId);
                    CargarParticipantes(eventoId);
                    ActualizarContadorParticipantes();
                }
                else
                {
                    MostrarError("No se pudo confirmar la asistencia");
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al confirmar asistencia: " + ex.Message);
            }
        }

        private bool ObtenerUsuarioActual(out int usuarioId)
        {
            usuarioId = 0;

            if (Session["usuarioActual"] == null)
                return false;

            try
            {
                var usuario = Session["usuarioActual"] as usuario;
                if (usuario != null)
                {
                    usuarioId = usuario.id;
                    return true;
                }

                // Si el casting directo falla, intentar con reflexión
                var prop = Session["usuarioActual"].GetType().GetProperty("id") ??
                          Session["usuarioActual"].GetType().GetProperty("Id");

                if (prop != null)
                {
                    usuarioId = (int)prop.GetValue(Session["usuarioActual"]);
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        private void VerificarAsistenciaUsuario(int idEvento, int idUsuario)
        {
            try
            {
                bool yaParticipa = eventoService.verificarParticipacionEvento(idEvento, idUsuario);
                btnAsistir.Visible = !yaParticipa;
                btnCancelarAsistencia.Visible = yaParticipa;
            }
            catch (Exception ex)
            {
                MostrarError("Error al verificar participación: " + ex.Message);
            }
        }

        private void MostrarError(string mensaje)
        {
            lblError.Text = mensaje;
            lblError.Visible = true;
            lblSuccess.Visible = false;
        }

        private void MostrarExito(string mensaje)
        {
            lblSuccess.Text = mensaje;
            lblSuccess.Visible = true;
            lblError.Visible = false;
        }

        private void CargarDatosEvento(int idEvento)
        {
            try
            {
                var evento = eventoService.buscarEventoPorId(idEvento);
                if (evento != null)
                {
                    litNombreEvento.Text = evento.nombre;
                    litDescripcion.Text = evento.descripcion;
                    litUbicacion.Text = evento.ubicacion;
                    litFechaEvento.Text = FormatearFecha(evento.fechaFinString);

                    // Configurar el banner con la imagen local
                    string imageUrl = GetLocalImagePath(evento.imagen);
                    eventBanner.Style["background-image"] = $"url('{imageUrl}')";

                    var participantes = eventoService.listarParticipantesPorEvento(idEvento);
                    litNumParticipantes.Text = participantes?.Length.ToString() ?? "0";
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al cargar el evento: " + ex.Message);
            }
        }

        private string FormatearFecha(string fechaString)
        {
            if (DateTime.TryParseExact(fechaString, "yyyy-MM-dd HH:mm:ss",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out DateTime fecha))
            {
                return fecha.ToString("dd 'de' MMMM 'de' yyyy 'a las' hh:mm tt");
            }
            return fechaString;
        }

        private void CargarParticipantes(int idEvento)
        {
            try
            {
                var participantes = eventoService.listarParticipantesPorEvento(idEvento);

                if (participantes != null && participantes.Length > 0)
                {
                    rptParticipantes.DataSource = participantes.Select(p => new {
                        Nombre = p.nombre,
                        Carrera = p.carrera
                    }).ToArray();

                    rptParticipantes.DataBind();
                    pnlNoParticipantes.Visible = false;
                }
                else
                {
                    pnlNoParticipantes.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al cargar participantes: " + ex.Message);
            }
        }

        private void ActualizarContadorParticipantes()
        {
            try
            {
                int eventoId = (int)ViewState["EventoId"];
                var participantes = eventoService.listarParticipantesPorEvento(eventoId);
                litNumParticipantes.Text = participantes != null ? participantes.Length.ToString() : "0";
            }
            catch
            {
                litNumParticipantes.Text = "0";
            }
        }

        public string GetLocalImagePath(string imageName)
        {
            try
            {
                if (string.IsNullOrEmpty(imageName))
                    return ResolveUrl("~/Images/default2_event.jpg");

                string nombreArchivo = CleanFileName(imageName);
                string rutaRelativa = $"~/Images/{nombreArchivo}";
                string rutaFisica = Server.MapPath(rutaRelativa);

                return File.Exists(rutaFisica) ? ResolveUrl(rutaRelativa) : ResolveUrl("~/Images/default2_event.jpg");
            }
            catch
            {
                return ResolveUrl("~/Images/default2_event.jpg");
            }
        }

        private string CleanFileName(string fileName)
        {
            string invalidChars = Regex.Escape(new string(Path.GetInvalidFileNameChars()));
            string invalidRegStr = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);
            return Regex.Replace(fileName, invalidRegStr, "_");
        }

    }
}