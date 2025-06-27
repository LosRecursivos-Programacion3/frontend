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
            if (!IsPostBack && Request.QueryString["error"] != null)
            {
                string errorMsg = Server.UrlDecode(Request.QueryString["error"]);
                LblError.Text = "Error: " + errorMsg;
            }
        }
        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            string email = TxtEmail.Text.Trim();
            string password = TxtPassword.Text.Trim();

            try
            {
                alumno us = usuarioWSClient.autenticarUsuario(email, password);

                if (us != null)
                {
                    Session["usuarioActual"] = us;

                    FormsAuthenticationTicket tkt;
                    string cookiestr;
                    HttpCookie ck;

                    tkt = new FormsAuthenticationTicket(1, email, DateTime.Now,
                        DateTime.Now.AddMinutes(30), true, "Datos adicionales");
                    cookiestr = FormsAuthentication.Encrypt(tkt);
                    ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr)
                    {
                        Expires = tkt.Expiration,
                        Path = FormsAuthentication.FormsCookiePath
                    };
                    Response.Cookies.Add(ck);

                    string strRedirect = Request["ReturnUrl"];
                    if (strRedirect == null)
                        strRedirect = "Main.aspx";

                    Response.Redirect(strRedirect, false);
                }
                else
                {
                    // No se encontró el alumno, error genérico
                    string error = Server.UrlEncode("Usuario o contraseña incorrectos.");
                    Response.Redirect("Login.aspx?error=" + error, false);
                }
            }
            catch (Exception ex)
            {
                string error = Server.UrlEncode(ex.Message);
                Response.Redirect("Login.aspx?error=" + error, false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }   

    }
}