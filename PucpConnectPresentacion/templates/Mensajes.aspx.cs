using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
// proxy SOAP Usuarios
// proxy SOAP Mensajes
using PucpConnectPresentacion.PUCPConnectWS;

namespace PucpConnectPresentacion.templates
{
    public partial class Mensajes : Page
    {
        [WebMethod]
        public static List<alumno> listarAmigos()
        {
            var usuarioActual = (alumno)HttpContext.Current.Session["usuarioActual"];
            if (usuarioActual == null) return new List<alumno>();

            var client = new UsuarioWSClient();
            var amigos = client.listarAmigosPorId(usuarioActual.idAlumno)
                         ?? Array.Empty<alumno>();
            return amigos.ToList();
        }

        public class MensajeDTO
        {
            public int EmisorId { get; set; }
            public int ReceptorId { get; set; }
            public string Contenido { get; set; }
            public string Timestamp { get; set; }
        }

        [WebMethod]
        public static List<MensajeDTO> CargarHistorial(int emisorId, int receptorId)
        {
            var usuarioActual = (alumno)HttpContext.Current.Session["usuarioActual"];
            // 1) Usa el proxy actualizado que ya conoce MensajeDTO con string Timestamp
            var client = new PucpConnectPresentacion.MensajeWSReference.MensajeWSClient();

            // 2) Llama al servicio
            var wsMsgs = client.obtenerMensajesEntreUsuarios(usuarioActual.idAlumno, receptorId)
                ?? Array.Empty<PucpConnectPresentacion.MensajeWSReference.mensajeDTO>();

            // 3) Mapea a tu DTO interno
            var lista = wsMsgs.Select(m => new MensajeDTO
            {
                EmisorId = m.emisorId,
                ReceptorId = m.receptorId,
                Contenido = m.contenido,
                // Parseas el ISO string sin fallback a Now, y luego formateas
                Timestamp = DateTime
                    .Parse(m.timestamp)        // m.timestamp es p. e. "2025-06-29T14:23:45"
                    .ToString("HH:mm")
            }).ToList();

            return lista;
        }
    }
}
