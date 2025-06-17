using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PucpConnectDomain;
using PucpConnectPresentacion.UsuarioWS;
using static PucpConnectPresentacion.UsuarioWS.UsuarioWS;

namespace PucpConnectPresentacion.templates
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private UsuarioWSClient usuarioWSClient;
        protected void Page_Load(object sender, EventArgs e)
        {
            usuarioWSClient = new UsuarioWSClient();
        }

        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                usuarioWSClient.registrarAlumno(
                    TxtNombre.Text.Trim(),
                    TxtPassword.Text.Trim(),
                    true, // estado
                    TxtEmail.Text.Trim(),
                    int.TryParse(TxtEdad.Text.Trim(), out int edad) ? edad : 0,
                    TxtCarrera.Text.Trim(),
                    FotoPerfilUpload.HasFile ? FotoPerfilUpload.FileName : "",
                    TxtUbicacion.Text.Trim(),
                    TxtBiografia.Text.Trim(),
                    true // visible
                );
                LblMensaje.Text = "Alumno registrado correctamente.";
            }
            catch (Exception ex)
            {
                LblMensaje.Text = "Error: " + ex.Message;
            }
        }
    }
}