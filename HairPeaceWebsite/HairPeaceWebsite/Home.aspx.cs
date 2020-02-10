using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HairPeaceWebsite.PeaceReference;

namespace HairPeaceWebsite
{
    public partial class Home : System.Web.UI.Page
    {
        HairServiceClient client = new HairServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
           

            dynamic Products = client.fillBySpecial();
            List<Prod> prods = new List<Prod>();
            if (Products != null)
            {
                foreach (Prod p in Products)
                {
                    prods.Add(p);
                }
            }
            Catalog.InnerHtml = Display(prods);

        }

        private string Display(List<Prod> Products)
        {
            string display = "";

            foreach (Prod Prod in Products)
            {
                display += "<div class='col-sm col-md-6 col-lg ftco-animate'>";
                display += "<div class='product'>";
                display += "<a href='productInfo.aspx?ID=" + Prod.ID + "' class='img-prod'><img class='img-fluid' src='" + Prod.Image + "' alt='Colorlib Template'>";
                //if Statements For discounts, New Arrivals & Best Sellers
                display += "<span class='status'>Best Sellers</span>";
                display += "</a>";
                display += "<div class='text py-3 px-3'>";
                display += "<h3><a href='#'>" + Prod.prodName + "</a></h3>";
                display += "<div class='d-flex'>";
                display += "<div class='pricing'>";
                display += "<p class='price'><span>$" + Math.Round(Prod.Price) + " </span></p>";
                display += "</div>";
                display += "</div>";
                if (Session["ID"] != null)
                {
                    String strID = Session["ID"].ToString();
                    display += "<hr>";
                    display += "<p class='bottom-area d-flex'>";
                    display += "<button type='button' style='postion:center;' class='btn btn-primary py-3 px-5' onclick='addCart(" + Prod.ID+","+strID+")'>Add to cart </button>";
                    display += "</p>";
                    //display += "<p class='"+Prod.ID+"Added'style='color:green; display:none;>Item Added!</p>";
                    //display += "<p class='"+Prod.ID+ "NoAdd'style='color:red; display:none; postion:center;'>Item not added to cart!</p>";
                }
                display += "</div>";
                display += "</div>";
                display += "</div>";
            }

            return display;
        }
    }
}