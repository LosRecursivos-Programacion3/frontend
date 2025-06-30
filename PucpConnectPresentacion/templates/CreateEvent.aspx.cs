using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using PucpConnectDomain;
using PucpConnectPresentacion.EventoWS;
using PucpConnectPresentacion.PUCPConnectWS;
using PucpConnectPresentacion.InteresWS;

namespace PucpConnectPresentacion.templates
{
    public partial class CreateEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarIntereses();
            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones básicas
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                    string.IsNullOrWhiteSpace(txtFechaInicio.Text) ||
                    string.IsNullOrWhiteSpace(txtHoraInicio.Text) ||
                    string.IsNullOrWhiteSpace(txtUbicacion.Text))
                {
                    MostrarError("Por favor complete todos los campos obligatorios");
                    return;
                }

                // Validar fechas
                DateTime fechaInicio, fechaFin;
                if (!DateTime.TryParse($"{txtFechaInicio.Text} {txtHoraInicio.Text}", out fechaInicio) ||
                    !DateTime.TryParse($"{txtFechaFin.Text} {txtHoraFin.Text}", out fechaFin))
                {
                    MostrarError("Formato de fecha/hora inválido");
                    return;
                }

                if (fechaInicio < DateTime.Now)
                {
                    MostrarError("La fecha del evento no puede ser anterior a la fecha actual");
                    return;
                }

                if (fechaFin < fechaInicio)
                {
                    MostrarError("La fecha de fin debe ser posterior a la fecha de inicio");
                    return;
                }

                // Obtener intereses seleccionados
                List<string> intereses = new List<string>();
                foreach (ListItem item in chkIntereses.Items)
                {
                    if (item.Selected)
                    {
                        intereses.Add(item.Value);
                    }
                }

                if (intereses.Count == 0)
                {
                    MostrarError("Seleccione al menos un interés");
                    return;
                }

                string interesesStr = string.Join(",", intereses);
                string fechaInicioStr = fechaInicio.ToString("yyyy-MM-dd HH:mm:ss");
                string fechaFinStr = fechaFin.ToString("yyyy-MM-dd HH:mm:ss");

                // Obtener ID del creador
                int creadorId = ObtenerIdCreador();
                if (creadorId == 0)
                {
                    MostrarError("No se pudo identificar al creador del evento");
                    return;
                }

                // Llamar al WS
                using (var client = new EventoWSClient())
                {
                    bool exito = client.crearEvento(
                        txtNombre.Text.Trim(),
                        txtDescripcion.Text.Trim(),
                        fechaInicioStr,
                        fechaFinStr,
                        txtUbicacion.Text.Trim(),
                        creadorId,
                        interesesStr);

                    if (exito)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "ShowSuccessModal",
                            "showSuccessModal();", true);
                    }
                    else
                    {
                        MostrarError("No se pudo crear el evento");
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarError($"Error inesperado: {ex.Message}");
            }
        }

        private void LimpiarFormulario()
        {
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtFechaInicio.Text = string.Empty;
            txtFechaFin.Text = string.Empty;
            txtHoraInicio.Text = string.Empty;
            txtHoraFin.Text = string.Empty;
            txtUbicacion.Text = string.Empty;

            foreach (ListItem item in chkIntereses.Items)
            {
                item.Selected = false;
            }
        }

        private bool ValidarIntereses()
        {
            foreach (ListItem item in chkIntereses.Items)
            {
                if (item.Selected)
                    return true;
            }
            return false;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Events.aspx");
        }

        private void MostrarError(string mensaje)
        {
            // Ahora que tenemos SweetAlert2 incluido, esto funcionará
            ScriptManager.RegisterStartupScript(this, GetType(), "showError",
                $"Swal.fire('Error', '{mensaje.Replace("'", "\\'")}', 'error');", true);
        }

        private int ObtenerIdCreador()
        {
            if (Session["usuarioActual"] == null)
                return 0;

            try
            {
                var usuario = Session["usuarioActual"] as PUCPConnectWS.usuario;
                return usuario?.id ?? 0;
            }
            catch
            {
                return 0;
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
    }
}