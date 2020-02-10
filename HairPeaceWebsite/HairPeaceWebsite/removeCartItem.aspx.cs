using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HairPeaceWebsite.PeaceReference;

namespace HairPeaceWebsite
{
    public partial class removeCartItem : System.Web.UI.Page
    {
        HairServiceClient client = new HairServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            int uID = Convert.ToInt32(Session["ID"].ToString());
            int pID = Convert.ToInt32(Request.QueryString["pID"]);

            if(Request.QueryString["frmCart"] == "yEb0")
            {
                client.decreasingQ(pID, uID);
                Response.Redirect("Cart.aspx");
            }
            else
            {
                bool removed = client.removeItem(uID, pID);

                if (removed)
                {
                    Response.Redirect("Cart.aspx");
                }
            }
        }
    }
}