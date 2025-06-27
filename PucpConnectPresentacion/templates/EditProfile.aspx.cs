using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PucpConnectPresentacion.PUCPConnectWS;

namespace PucpConnectPresentacion.templates
{
    public partial class EditProfile : System.Web.UI.Page
    {
        private UsuarioWSClient usuarioWSClient;

        protected void Page_Load(object sender, EventArgs e)
        {
            usuarioWSClient = new UsuarioWSClient();

            if (!IsPostBack) // Esto es crucial para que no se sobrescriba al hacer clic en el botón
            {
                var usuario = (alumno)Session["usuarioActual"];
                if (usuario == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                // Asignar valores a los controles del formulario
                txtNombre.Text = usuario.nombre;
                txtEmail.Text = usuario.email;
                txtEdad.Text = usuario.edad.ToString();
                txtCarrera.Text = usuario.carrera;
                txtUbicacion.Text = usuario.ubicacion;
                txtBiografia.Text = usuario.biografia;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            var usuario = (alumno)Session["usuarioActual"];
            if (usuario == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            // Actualiza los valores
            usuario.nombre = txtNombre.Text.Trim();
            usuario.email = txtEmail.Text.Trim();
            usuario.edad = int.TryParse(txtEdad.Text.Trim(), out int edad) ? edad : usuario.edad;
            usuario.carrera = txtCarrera.Text.Trim();
            usuario.ubicacion = txtUbicacion.Text.Trim();
            usuario.biografia = txtBiografia.Text.Trim();

            // Guardar imagen si se subió
            if (fuFotoPerfil.HasFile)
            {
                string fileName = Path.GetFileName(fuFotoPerfil.FileName);
                string filePath = Server.MapPath("~/Images/") + fileName;
                fuFotoPerfil.SaveAs(filePath);
                usuario.fotoPerfil = fileName;
            }

            // Actualizar en BD vía WebService
            try
            {
                bool actualizado = usuarioWSClient.actualizarAlumno(
                    usuario.id,
                    usuario.idAlumno,
                    usuario.nombre,
                    usuario.edad,
                    usuario.carrera,
                    usuario.fotoPerfil,
                    usuario.ubicacion,
                    usuario.biografia
                );

                if (actualizado)
                {
                    Session["usuarioActual"] = usuario; // Actualiza la sesión
                    Response.Redirect("Profile.aspx");
                }
                else
                {
                    lblMensaje.Text = "No se pudo actualizar el perfil.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al actualizar: " + ex.Message;
            }
        }
        
        protected void btnEditarIntereses_Click(object sender, EventArgs e)
        {
            Response.Redirect("SelectInterest.aspx");
            return;
        }
        protected void btnEditarPassword_Click(object sender, EventArgs e)
        {

        }
    }
}