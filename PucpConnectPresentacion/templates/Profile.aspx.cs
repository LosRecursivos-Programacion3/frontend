using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PucpConnectPresentacion
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConfigurar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProfileModify.aspx");
        }

        protected void btnConfigureInterests_Click(object sender, EventArgs e) {
            Response.Redirect("InteresModify.aspx");
        }
    }
}