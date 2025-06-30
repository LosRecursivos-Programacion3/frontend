using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using PucpConnectPresentacion.EventoWS;
using PucpConnectPresentacion.InteresWS;

namespace PucpConnectPresentacion.templates
{
    public partial class Events : System.Web.UI.Page
    {
        private EventoWSClient _eventoWS = new EventoWSClient();
        private InteresWSClient _interesWS = new InteresWSClient();
        private List<InteresWS.interes> _todosIntereses;
        private int? _interesFiltrado;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarIntereses();
                CargarEventos();
            }
            _interesFiltrado = ViewState["InteresFiltrado"] as int?;
        }

        private void CargarIntereses()
        {
            try
            {
                _todosIntereses = _interesWS.listarInteres()?.ToList() ?? new List<InteresWS.interes>();
                _todosIntereses = _todosIntereses.OrderBy(i => i.nombre).ToList();

                rptFiltrosIntereses.DataSource = _todosIntereses;
                rptFiltrosIntereses.DataBind();

                //filterPagination.Visible = _todosIntereses.Count > 20;
            }
            catch (Exception ex)
            {
                MostrarError("Error al cargar intereses: " + ex.Message);
            }
        }

        private void CargarEventos(int? idInteres = null)
        {
            try
            {
                evento[] eventos;
                _interesFiltrado = idInteres;
                ViewState["InteresFiltrado"] = idInteres;

                if (idInteres.HasValue)
                {
                    eventos = _eventoWS.listarEventosPorInteres(idInteres.Value)?.ToArray() ?? Array.Empty<evento>();
                    var interesSeleccionado = _todosIntereses?.FirstOrDefault(i => i.id == idInteres.Value);
                    lblFiltroActivo.Text = interesSeleccionado?.nombre ?? "Interés seleccionado";
                    pnlFiltroActivo.Visible = true;
                }
                else
                {
                    eventos = _eventoWS.listarEventos()?.ToArray() ?? Array.Empty<evento>();
                    pnlFiltroActivo.Visible = false;
                }

                if (eventos.Length > 0)
                {
                    rptEventos.DataSource = eventos;
                    rptEventos.DataBind();
                    pnlEventos.Visible = true;
                    pnlNoEventos.Visible = false;
                }
                else
                {
                    MostrarMensajeNoEventos(idInteres);
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al cargar eventos: " + ex.Message);
            }
        }

        private void MostrarMensajeNoEventos(int? idInteres)
        {
            pnlEventos.Visible = false;
            pnlNoEventos.Visible = true;
            lblNoResultados.Text = idInteres.HasValue ?
                $"No hay eventos para el interés seleccionado" :
                "No hay eventos disponibles actualmente";
        }

        protected void FiltrarPorInteres(object sender, CommandEventArgs e)
        {
            if (int.TryParse(e.CommandArgument?.ToString(), out int idInteres))
            {
                CargarEventos(idInteres);
            }
        }

        protected void LimpiarFiltro(object sender, EventArgs e)
        {
            CargarEventos();
        }

        public string ObtenerRutaImagen(object imagenObj)
        {
            string nombreArchivo = imagenObj?.ToString()?.Trim();
            return !string.IsNullOrEmpty(nombreArchivo) && System.IO.File.Exists(Server.MapPath($"~/Images/{nombreArchivo}")) ?
                ResolveUrl($"~/Images/{nombreArchivo}") :
                ResolveUrl("~/Images/default-event.jpg");
        }

        public string FormatearFecha(object fechaObj)
        {
            if (fechaObj != null && DateTime.TryParse(fechaObj.ToString(), out DateTime fecha))
            {
                return fecha.ToString("dd MMM yyyy", new System.Globalization.CultureInfo("es-ES"));
            }
            return "Fecha no definida";
        }

        public List<EventoWS.interes> ObtenerInteresesEvento(object eventoItem)
        {
            if (eventoItem is evento ev && ev.idEvento > 0)
            {
                try
                {
                    return _eventoWS.listarInteresesPorEvento(ev.idEvento)?.ToList() ?? new List<EventoWS.interes>();
                }
                catch
                {
                    return new List<EventoWS.interes>();
                }
            }
            return new List<EventoWS.interes>();
        }

        private void MostrarError(string mensaje)
        {
            lblError.Text = mensaje;
            lblError.Visible = true;
            pnlEventos.Visible = false;
            pnlNoEventos.Visible = true;
        }
    }
}