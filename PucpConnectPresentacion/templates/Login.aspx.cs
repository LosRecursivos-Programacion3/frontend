using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using PucpConnectDomain;
using PucpConnectPresentacion.PUCPConnectWS;

namespace PucpConnectPresentacion
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private UsuarioWSClient usuarioWSClient;
        protected void Page_Load(object sender, EventArgs e)
        {
            usuarioWSClient = new PUCPConnectWS.UsuarioWSClient();
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            string email = TxtEmail.Text.Trim();
            string password = TxtPassword.Text.Trim();
            usuario us = usuarioWSClient.autenticarUsuario(email, password);
            if (us!=null)
            {
                FormsAuthenticationTicket tkt;
                string cookiestr;
                HttpCookie ck;
                tkt = new FormsAuthenticationTicket(1, email, DateTime.Now,
                DateTime.Now.AddMinutes(30), true, us.nombre);
                cookiestr = FormsAuthentication.Encrypt(tkt);
                ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
                ck.Expires = tkt.Expiration; //esto genera que la cookie se quede guardada
                ck.Path = FormsAuthentication.FormsCookiePath;
                Response.Cookies.Add(ck);

                string strRedirect;
                strRedirect = Request["ReturnUrl"];
                if (strRedirect == null)
                    strRedirect = "Main.aspx";
                Response.Redirect(strRedirect, true);
            }
            else
            {
                // Autenticación fallida: redirige o muestra mensaje
                Response.Redirect("Login.aspx?error=1", true);
            }
        }
    }
}