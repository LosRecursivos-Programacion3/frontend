using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PucpConnectPresentacion.templates
{
    public partial class Profile_Friends : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null) // o el nombre que uses
            {
                Response.Redirect("~/templates/Login.aspx");
            }
        }
    }
}