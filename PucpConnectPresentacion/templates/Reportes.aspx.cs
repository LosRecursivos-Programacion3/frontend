using System;
using System.Web.UI;
using PucpConnectPresentacion.ReporteWS;

namespace PucpConnectPresentacion
{
    public partial class Reportes : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblError.Visible = false;
            }
        }

        protected void btnIrAlMain_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/templates/Main.aspx");
        }

        protected void btnDescargarUsuarios_Click(object sender, EventArgs e)
        {
            DownloadReport("Reporte_Usuarios.pdf", () =>
            {
                using (var cliente = new ReporteWSClient())
                {
                    return cliente.ReporteUsuarios();
                }
            });
        }

        protected void btnDescargarEventos_Click(object sender, EventArgs e)
        {
            DownloadReport("Reporte_Eventos.pdf", () =>
            {
                using (var cliente = new ReporteWSClient())
                {
                    return cliente.generarReporteEventosConParticipantes();
                }
            });
        }

        protected void btnDescargarCarreras_Click(object sender, EventArgs e)
        {
            DownloadReport("Reporte_Carreras.pdf", () =>
            {
                using (var cliente = new ReporteWSClient())
                {
                    return cliente.ReporteCantAlumnosPorCarrera();
                }
            });
        }

        private void DownloadReport(string filename, Func<byte[]> reportGenerator)
        {
            try
            {
                byte[] archivo = reportGenerator();

                if (archivo != null && archivo.Length > 0)
                {
                    Response.Clear();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("Content-Disposition", $"attachment; filename={filename}");
                    Response.BinaryWrite(archivo);
                    Response.End();
                }
                else
                {
                    ShowError($"El reporte {filename} está vacío o no contiene datos");
                }
            }
            catch (Exception ex)
            {
                ShowError($"Error al generar el reporte: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"ERROR: {ex}");
            }
        }

        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
        }
    }
}
