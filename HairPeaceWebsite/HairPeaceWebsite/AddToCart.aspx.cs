using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HairPeaceWebsite.PeaceReference;

namespace HairPeaceWebsite
{
    public partial class AddToCart : System.Web.UI.Page
    {
        HairServiceClient client = new HairServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            int uID = Convert.ToInt32(Session["ID"].ToString());
            int pID = Convert.ToInt32(Request.QueryString["pID"]);
            string frm = Request.QueryString["frm"];
            userCart cart = new userCart
            {
                User_ID = uID,
                Prod_ID = pID,
                Quantity = 1
            };
            
            if(frm.Equals("home"))
            {
                if (client.itemExists(uID, pID))
                {
                    if (client.editCart(uID, pID))
                    {
                        Response.Redirect("Home.aspx?pID=" + pID);
                    }
                }
                else
                {
                    if (client.addToCart(cart))
                    {
                        Response.Redirect("Home.aspx?pID=" + pID);
                    }
                }
            }
            else if(frm.Equals("cart"))
            {
                if (client.editCart(uID, pID))
                {
                    Response.Redirect("Cart.aspx?pID=" + pID);
                }
            }
            else if (frm.Equals("catalog"))
            {
                if (client.itemExists(uID, pID))
                {
                    if (client.editCart(uID, pID))
                    {
                        Response.Redirect("WebCatalog.aspx?pID=" + pID);
                    }
                }
                else
                {
                    if (client.addToCart(cart))
                    {
                        Response.Redirect("WebCatalog.aspx?pID=" + pID);
                    }
                }
            }
            else if (frm.Equals("pInfor"))
            {
                if (client.itemExists(uID, pID))
                {
                    if (client.editCart(uID, pID))
                    {
                        Response.Redirect("productInfo.aspx?pID=" + pID);
                    }
                }
                else
                {
                    if (client.addToCart(cart))
                    {
                        Response.Redirect("productInfo.aspx?pID=" + pID);
                    }
                }
            }




        }
    }
}