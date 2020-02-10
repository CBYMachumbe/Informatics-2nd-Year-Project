using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HairPeaceWebsite.PeaceReference;

namespace HairPeaceWebsite
{
    public partial class HairPeace : System.Web.UI.MasterPage
    {
        HairServiceClient client = new HairServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Usertype"] != null)
            {
                signIn.Visible = false;
                Logout.Visible = true;
                cartlink.Visible = true;
                checkoutlink.Visible = true;
                invoices.Visible = true;
                cartTag();

                if (Session["Usertype"].ToString() == "Admin")
                {
                    AdminTools.Visible = true;
                }
                else if (Session["Usertype"].ToString() == "Manager")
                {
                    cartTag();
                    AdminTools.Visible = true;
                    search.Visible = true;
                    register.Visible = true;
                }
            }
            
        }

        private void cartTag()
        {
            int i = client.getTotalItems(Convert.ToInt32(Session["ID"].ToString()));
            CartIcon.Visible = true;
            CartIcon.InnerHtml = "<span class='icon-shopping_cart'></span>[" + i + "]";
        }

    }
}