using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PucpConnectPresentacion.PUCPConnectWS;

namespace PucpConnectPresentacion.templates
{
    public partial class SelectInterest : System.Web.UI.Page
    {
        private UsuarioWSClient usuarioWSClient;
        private List<int> seleccionados = new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            usuarioWSClient = new PUCPConnectWS.UsuarioWSClient();

            try
            {

                // 1. Obtener ID del alumno autenticado
                var alumno = (alumno)Session["usuarioActual"];
                if (alumno == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }
                int idAlumno = alumno.idAlumno;

                // 2. Obtener intereses generales y los del alumno
                var todosLosIntereses = usuarioWSClient.listarIntereses();
                var interesesAlumno = usuarioWSClient.obtenerInteresesUsuario(idAlumno);

                // Si no hay intereses previos, crea una lista vacía
                if (interesesAlumno != null)
                    seleccionados = interesesAlumno.Select(i => i.id).ToList();
                else
                    seleccionados = new List<int>();

                // 4. Guardar ambos en ViewState para acceder en DataBound
                ViewState["InteresesAlumno"] = seleccionados;
                rptIntereses.DataSource = todosLosIntereses;
                rptIntereses.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("Error desde WS: " + ex.Message);
            }
        }

        protected void rptIntereses_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var interes = (interes)e.Item.DataItem;

                var chk = (CheckBox)e.Item.FindControl("chkInteres");
                if (chk != null)
                {
                    // Puedes usar ToolTip o ID para almacenar el ID del interés si necesitas recuperarlo después
                    chk.ToolTip = interes.id.ToString();

                    // Verifica si el interés está entre los ya seleccionados
                    List<int> interesesAlumno = ViewState["InteresesAlumno"] as List<int>;
                    if (interesesAlumno != null && interesesAlumno.Contains(interes.id))
                    {
                        chk.Checked = true;
                    }
                }

                var hdn = (HiddenField)e.Item.FindControl("hdnId");
                if (hdn != null)
                {
                    hdn.Value = interes.id.ToString();
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var alumno = (alumno)Session["usuarioActual"];
                if (alumno == null)
                {
                    Response.Write("Error: No hay sesión activa.");
                    return;
                }

                int idAlumno = alumno.idAlumno;

                // ✅ Leer el valor del hidden field
                string seleccionadosRaw = hdnSeleccionados.Value;
                List<int> seleccionados = new List<int>();

                if (!string.IsNullOrWhiteSpace(seleccionadosRaw))
                {
                    foreach (string idStr in seleccionadosRaw.Split(','))
                    {
                        if (int.TryParse(idStr, out int id))
                            seleccionados.Add(id);
                    }
                }

                if (seleccionados.Count == 0)
                {
                    Response.Write("No se seleccionó ningún interés.");
                    return;
                }

                usuarioWSClient.registrarInteresesUsuario(idAlumno, seleccionados.ToArray());

                Response.Redirect("SelectInterest.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                Response.Write("Error al guardar intereses: " + ex.Message + "<br/>" + ex.StackTrace);
            }
        }
    }
}