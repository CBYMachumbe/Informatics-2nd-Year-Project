using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HairPeaceWebsite
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Usertype"] = null;
            Session["Email"] = null;
            Session["Password"] = null;
            Session["ID"] = null;
            Response.Redirect("Home.aspx");
        }
    }
}