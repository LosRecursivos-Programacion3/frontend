using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PucpConnectDomain;
using PucpConnectPresentacion.PucpConnectWS;

namespace PucpConnectPresentacion.templates
{
    public partial class CreateEvent : System.Web.UI.Page
    {
        private PucpConnectWS.EventoWSClient client;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["mensajeExito"] != null)
            {
                string mensaje = Session["mensajeExito"].ToString();
                Session.Remove("mensajeExito");
                Response.Write($"<script>alert('{mensaje}');</script>");
            }
        }


        protected void Page_Init(object sender, EventArgs e)
        {
            client = new EventoWSClient(); 

        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNombre.Text) ||
                    string.IsNullOrEmpty(txtDescripcion.Text) ||
                    string.IsNullOrEmpty(txtUbicacion.Text) ||
                    string.IsNullOrEmpty(txtFechaInicio.Text))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        "alert('Complete todos los campos requeridos');", true);
                    return;
                }

                // Intentar parsear la fecha y hora si se proporciona, o solo la fecha
                DateTime fechaEvento;
                string[] formatos = { "yyyy-MM-dd", "yyyy-MM-dd HH:mm", "yyyy-MM-ddTHH:mm", "dd/MM/yyyy", "dd/MM/yyyy HH:mm" };
                if (!DateTime.TryParseExact(txtFechaInicio.Text, formatos, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fechaEvento))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        "alert('Fecha inválida. Ingrese una fecha válida en formato yyyy-MM-dd o dd/MM/yyyy.');", true);
                    return;
                }
                // Formato compatible con el backend: yyyy-MM-ddTHH:mm:ss
                string fechaEventoStr = fechaEvento.ToString("yyyy-MM-dd'T'HH:mm:ss");

                Alumno creador = Session["alumno"] as Alumno ?? new Alumno
                {
                    Nombre = "Usuario Temporal",
                    Email = "temp@pucp.edu.pe"
                    // completa con otros campos requeridos
                };

                // 4. Llamar al servicio web (ajustado para pasar id_creador)
                int idCreador = 1;
                // Intenta obtener el id del alumno si existe
                var tipo = creador.GetType();
                var prop = tipo.GetProperty("id") ?? tipo.GetProperty("Id") ?? tipo.GetProperty("ID");
                if (prop != null)
                {
                    idCreador = Convert.ToInt32(prop.GetValue(creador, null));
                }

                using (client)
                {
                    bool exito = client.registrarEvento(
                        txtNombre.Text,
                        txtDescripcion.Text,
                        fechaEventoStr, // fecha en formato compatible
                        txtUbicacion.Text,
                        idCreador // id del creador
                    );

                    if (exito)
                    {
                        // Redirigir con mensaje de éxito
                        Session["mensajeExito"] = "Evento creado correctamente";
                        Response.Redirect("Main.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    $"alert('Error: {ex.Message.Replace("'", "")}');", true);
            }
        }
    }
}
