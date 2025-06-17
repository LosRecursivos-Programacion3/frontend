using System;
using System.Web;
using System.Web.UI;

namespace PucpConnectPresentacion.templates
{
    public partial class Logout : Page  // Asegúrate de heredar de Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            Response.Redirect("Login.aspx"); // Cambia según tu ruta real
        }
    }
}