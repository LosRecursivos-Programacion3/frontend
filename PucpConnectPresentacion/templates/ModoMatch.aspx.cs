using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PucpConnectPresentacion.PUCPConnectWS;
namespace PucpConnectPresentacion.templates
{
    public partial class ModoMatch : System.Web.UI.Page
    {
        private UsuarioWSClient usuarioWSClient;
        private List<alumno> listaAlumnos
        {
            get => Session["listaAlumnosMatch"] as List<alumno>;
            set => Session["listaAlumnosMatch"] = value;
        }

        private int indiceActual
        {
            get => (int)(ViewState["indiceActual"] ?? 0);
            set => ViewState["indiceActual"] = value;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            usuarioWSClient = new PUCPConnectWS.UsuarioWSClient();
            if (!IsPostBack)
            {
                var alumnoActual = (alumno)Session["usuarioActual"];
                if (alumnoActual == null)
                {
                    Response.Redirect("Login.aspx?returnUrl=ModoMatch.aspx");
                    return;
                }

                // Obtener lista de alumnos desde el WS
                var alumnos = usuarioWSClient.listarSugeridos_Para_Match(alumnoActual.idAlumno);
                listaAlumnos = alumnos.ToList();
                indiceActual = 0;
                CargarAlumnoActual();
            }
        }

        private void CargarAlumnoActual()
        {
            if (listaAlumnos == null || listaAlumnos.Count == 0 || indiceActual >= listaAlumnos.Count)
            {
                lblNombre.Text = "No hay más sugerencias";
                lblBiografia.Text = "";
                lblCarrera.Text = "";
                imgFotoPerfil.ImageUrl = "../Images/default.jpg"; // opcional
                btnAceptar.Enabled = false;
                btnRechazar.Enabled = false;
                btnAceptar.Visible = false;
                btnRechazar.Visible = false;
                btnVolver.Visible = true; // Mostrar botón de volver

                litIntereses.Text = "";
                return;
            }

            alumno a = listaAlumnos[indiceActual];
            lblNombre.Text = a.nombre;
            lblBiografia.Text = a.biografia;
            lblCarrera.Text = a.carrera;
            imgFotoPerfil.ImageUrl = string.IsNullOrEmpty(a.fotoPerfil)
                ? "../Images/blank-profile.png"
                : $"../Images/{a.fotoPerfil}";
            var interesesDelAlumno = usuarioWSClient.obtenerInteresesUsuario(a.idAlumno);

            StringBuilder sb = new StringBuilder();

            if (interesesDelAlumno != null)
            {
                foreach (var interes in interesesDelAlumno)
                {
                    sb.Append($"<span class='interest-tag'>{interes.nombre}</span>");
                }
            }

            litIntereses.Text = sb.ToString();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if(listaAlumnos == null || indiceActual >= listaAlumnos.Count)
                return;

            alumno alumnoSeleccionado = listaAlumnos[indiceActual];
            alumno alumnoActual = (alumno)Session["usuarioActual"];

            int idUno = alumnoActual.idAlumno;
            int idDos = alumnoSeleccionado.idAlumno;

            int idInteraccion = usuarioWSClient.existeInteraccion(idDos, idUno);

            if (idInteraccion != -1)
            {
                usuarioWSClient.confirmarMatch(idInteraccion);
                // Guardar temporalmente el alumno con quien hizo match (para usar en botones del modal)
                Session["matchAlumno"] = alumnoSeleccionado;

                // Mostrar el modal desde C#
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarModal", "$('#modalMatch').modal('show');", true);

                return;

            }
            else
            {
                usuarioWSClient.crearInteraccion(idUno, idDos);
            }
            indiceActual++;
            CargarAlumnoActual();

        }

        protected void btnRechazar_Click(object sender, EventArgs e)
        {
            // Aquí podrías registrar el rechazo si deseas
            indiceActual++;
            CargarAlumnoActual();
        }

        protected void btnAgregarAmigo_Click(object sender, EventArgs e)
        {
            var alumnoActual = (alumno)Session["usuarioActual"];
            var alumnoMatch = (alumno)Session["matchAlumno"];

            if (alumnoActual != null && alumnoMatch != null)
            {
                int idUno = alumnoActual.idAlumno;
                int idDos = alumnoMatch.idAlumno;
                usuarioWSClient.agregarAmistad(idUno, idDos); // o como se llame tu función
                Response.Redirect($"Mensajes.aspx");
            }

            indiceActual++;
            CargarAlumnoActual();
        }
    }
}