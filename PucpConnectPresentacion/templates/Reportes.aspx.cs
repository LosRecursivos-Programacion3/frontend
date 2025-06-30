using System;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using PucpConnectPresentacion.PUCPConnectWS;
using PucpConnectPresentacion.ReporteWS;
namespace PucpConnectPresentacion
{
    public partial class Reportes : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnEventos_Click(object sender, EventArgs e)
        {
            var cliente = new ReporteWSClient();
            byte[] archivo = cliente.generarReporteEventosConParticipantes();

            MostrarPDF(archivo, "ReporteEventos.pdf");
        }

        protected void btnCarreras_Click(object sender, EventArgs e)
        {
            var cliente = new ReporteWSClient();
            byte[] archivo = cliente.generarReportePorcentajeAlumnosPorCarrera();

            MostrarPDF(archivo, "ReporteCarreras.pdf");
        }

        private void MostrarPDF(byte[] data, string nombreArchivo)
        {
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "inline; filename=" + nombreArchivo);
            Response.BinaryWrite(data);
            Response.End();
        }
    }
}
