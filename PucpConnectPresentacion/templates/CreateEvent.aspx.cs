using System;
using System.Web.UI;
using PucpConnectPresentacion.EventoWS;
using PucpConnectPresentacion.PUCPConnectWS;
using PucpConnectPresentacion.InteresWS;
using System.Linq;
using System.Web.UI.WebControls;
using System.IO;

namespace PucpConnectPresentacion.templates
{
    public partial class CreateEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarIntereses();
                ScriptManager.RegisterStartupScript(this, GetType(), "initIntereses", "actualizarContadorIntereses();", true);
            }
        }

        private void CargarIntereses()
        {
            try
            {
                using (var client = new InteresWSClient())
                {
                    var intereses = client.listarInteres();
                    chkIntereses.DataSource = intereses;
                    chkIntereses.DataTextField = "nombre";
                    chkIntereses.DataValueField = "id";
                    chkIntereses.DataBind();
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al cargar intereses: " + ex.Message);
            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            string nombreImagen = null;
            string rutaGuardado = null;

            try
            {
                // Validaciones básicas
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                    string.IsNullOrWhiteSpace(txtFecha.Text) ||
                    string.IsNullOrWhiteSpace(txtHoraInicio.Text) ||
                    string.IsNullOrWhiteSpace(txtHoraFin.Text) ||
                    string.IsNullOrWhiteSpace(txtUbicacion.Text))
                {
                    MostrarError("Complete todos los campos obligatorios");
                    return;
                }

                // Validar intereses seleccionados
                var interesesSeleccionados = chkIntereses.Items.Cast<ListItem>()
                    .Where(item => item.Selected)
                    .Select(item => item.Value)
                    .ToList();

                if (interesesSeleccionados.Count == 0)
                {
                    MostrarError("Seleccione al menos un interés");
                    return;
                }

                if (interesesSeleccionados.Count > 5)
                {
                    MostrarError("Seleccione máximo 5 intereses");
                    return;
                }

                // Validar fechas y horas
                if (!DateTime.TryParse(txtFecha.Text + " " + txtHoraInicio.Text, out DateTime fechaInicio) ||
                    !DateTime.TryParse(txtFecha.Text + " " + txtHoraFin.Text, out DateTime fechaFin))
                {
                    MostrarError("Formato de fecha/hora inválido");
                    return;
                }
                if (fechaInicio.Date < DateTime.Today)
                {
                    MostrarError("La fecha del evento debe ser posterior al día actual");
                    return;
                }


                if (fechaInicio.TimeOfDay < TimeSpan.FromHours(7) || fechaInicio.TimeOfDay > TimeSpan.FromHours(19))
                {
                    MostrarError("Hora inicio debe ser entre 7:00 AM y 7:00 PM");
                    return;
                }

                if (fechaFin.TimeOfDay < TimeSpan.FromHours(8) || fechaFin.TimeOfDay > TimeSpan.FromHours(22))
                {
                    MostrarError("Hora fin debe ser entre 8:00 AM y 10:00 PM");
                    return;
                }

                TimeSpan diferencia = fechaFin - fechaInicio;
                if (diferencia.TotalMinutes < 30)
                {
                    MostrarError("La duración del evento debe ser de al menos 30 minutos");
                    return;
                }

                if (fechaFin <= fechaInicio)
                {
                    MostrarError("La hora fin debe ser después de la hora inicio");
                    return;
                }

                // Validar imagen (pero no guardarla todavía)
                if (fileUploadImagen.HasFile)
                {
                    string extension = Path.GetExtension(fileUploadImagen.FileName).ToLower();
                    if (!new[] { ".jpg", ".jpeg", ".png", ".gif" }.Contains(extension))
                    {
                        MostrarError("Formato de imagen no válido. Use JPG, JPEG, PNG o GIF");
                        return;
                    }

                    if (fileUploadImagen.PostedFile.ContentLength > 5 * 1024 * 1024) // 5MB
                    {
                        MostrarError("La imagen no puede superar los 5MB");
                        return;
                    }

                    // Preparar nombre y ruta pero no guardar todavía
                    nombreImagen = SanitizarNombreArchivo(Path.GetFileName(fileUploadImagen.FileName));
                    rutaGuardado = Server.MapPath("~/uploads/eventos/");
                }

                // Si llegamos aquí, todas las validaciones pasaron
                // Ahora podemos guardar la imagen
                if (fileUploadImagen.HasFile && !string.IsNullOrEmpty(rutaGuardado))
                {
                    // Crear directorio si no existe
                    if (!Directory.Exists(rutaGuardado))
                    {
                        Directory.CreateDirectory(rutaGuardado);
                    }

                    fileUploadImagen.SaveAs(Path.Combine(rutaGuardado, nombreImagen));
                }

                // Crear evento
                using (var client = new EventoWSClient())
                {
                    bool exito = client.crearEvento(
                        txtNombre.Text.Trim(),
                        txtDescripcion.Text.Trim(),
                        fechaInicio.ToString("yyyy-MM-dd HH:mm:ss"),
                        fechaFin.ToString("yyyy-MM-dd HH:mm:ss"),
                        txtUbicacion.Text.Trim(),
                        ObtenerIdUsuario(),
                        string.Join(",", interesesSeleccionados),
                        nombreImagen);

                    if (exito)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "mostrarModal",
                            "mostrarModalExito();", true);
                    }
                    else
                    {
                        // Si falla la creación del evento, eliminar la imagen subida
                        if (!string.IsNullOrEmpty(nombreImagen) && !string.IsNullOrEmpty(rutaGuardado))
                        {
                            string rutaImagen = Path.Combine(rutaGuardado, nombreImagen);
                            if (File.Exists(rutaImagen))
                            {
                                File.Delete(rutaImagen);
                            }
                        }
                        MostrarError("Error al crear el evento");
                    }
                }
            }
            catch (Exception ex)
            {
                // Si ocurre un error, eliminar la imagen subida si existe
                if (!string.IsNullOrEmpty(nombreImagen) && !string.IsNullOrEmpty(rutaGuardado))
                {
                    string rutaImagen = Path.Combine(rutaGuardado, nombreImagen);
                    if (File.Exists(rutaImagen))
                    {
                        File.Delete(rutaImagen);
                    }
                }
                MostrarError("Error: " + ex.Message);
            }
        }

        protected void btnVerEventos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/templates/Events.aspx");
        }

        protected void btnIrAlMain_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/templates/Main.aspx");
        }

        private int ObtenerIdUsuario()
        {
            if (Session["usuarioActual"] is PUCPConnectWS.usuario usuario)
                return usuario.id;
            return 0;
        }

        private void MostrarError(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showError",
                $"document.getElementById('errorMessage').textContent = '{mensaje.Replace("'", "\\'")}'; " +
                "document.getElementById('errorAlert').classList.remove('d-none');", true);
        }

        private string SanitizarNombreArchivo(string nombreArchivo)
        {
            // Eliminar caracteres inválidos y espacios
            var invalidChars = Path.GetInvalidFileNameChars();
            var sanitized = new string(nombreArchivo
                .Where(c => !invalidChars.Contains(c))
                .ToArray())
                .Replace(" ", "_")
                .ToLower();

            // Limitar longitud
            return sanitized.Length > 100 ? sanitized.Substring(0, 100) : sanitized;
        }
    }
}
