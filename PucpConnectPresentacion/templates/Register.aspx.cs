using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PucpConnectDomain;
using PucpConnectPresentacion.PUCPConnectWS;


namespace PucpConnectPresentacion.templates
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private UsuarioWSClient usuarioWSClient;
        protected void Page_Load(object sender, EventArgs e)
        {
            usuarioWSClient = new PUCPConnectWS.UsuarioWSClient();

        }

        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = TxtNombre.Text.Trim();
                string email = TxtEmail.Text.Trim();
                string password = TxtPassword.Text.Trim();
                string carrera = DropCarrera.SelectedValue;
                string ubicacion = TxtUbicacion.Text.Trim();
                string biografia = TxtBiografia.Text.Trim();
                string foto = FotoPerfilUpload.HasFile ? FotoPerfilUpload.FileName : "";

                if (password.Length < 5)
                {
                    LblMensaje.ForeColor = System.Drawing.Color.Red;
                    LblMensaje.Text = "La contraseña debe contener mínimo 6 caracteres.";
                    return;
                }
                // Validaciones
                if (nombre.Length > 50)
                {
                    LblMensaje.ForeColor = System.Drawing.Color.Red;
                    LblMensaje.Text = "El nombre no puede exceder los 50 caracteres.";
                    return;
                }

                if (!int.TryParse(TxtEdad.Text.Trim(), out int ed) || ed < 16)
                {
                    LblMensaje.ForeColor = System.Drawing.Color.Red;
                    LblMensaje.Text = "La edad debe ser un número entero mayor o igual a 16.";
                    return;
                }

                if (ubicacion.Length > 80)
                {
                    LblMensaje.ForeColor = System.Drawing.Color.Red;
                    LblMensaje.Text = "La ubicación no puede exceder los 80 caracteres.";
                    return;
                }

                if (biografia.Length > 500)
                {
                    LblMensaje.ForeColor = System.Drawing.Color.Red;
                    LblMensaje.Text = "La biografía no puede exceder los 500 caracteres.";
                    return;
                }
                if (string.IsNullOrEmpty(carrera))
                {
                    LblMensaje.ForeColor = System.Drawing.Color.Red;
                    LblMensaje.Text = "Debes seleccionar una carrera.";
                    return;
                }

                usuarioWSClient.registrarAlumno(
                    TxtNombre.Text.Trim(),
                    TxtPassword.Text.Trim(),
                    true, // estado
                    TxtEmail.Text.Trim(),
                    int.TryParse(TxtEdad.Text.Trim(), out int edad) ? edad : 0,
                    DropCarrera.SelectedValue,
                    FotoPerfilUpload.HasFile ? FotoPerfilUpload.FileName : "",
                    TxtUbicacion.Text.Trim(),
                    TxtBiografia.Text.Trim(),
                    true // visible
                );
                LblMensaje.ForeColor = System.Drawing.Color.Green;
                LblMensaje.Text = "Alumno registrado correctamente.";
            }
            catch (Exception ex)
            {
                LblMensaje.ForeColor = System.Drawing.Color.Red;
                LblMensaje.Text = "Error: " + ex.Message;
            }
        }
    }
}