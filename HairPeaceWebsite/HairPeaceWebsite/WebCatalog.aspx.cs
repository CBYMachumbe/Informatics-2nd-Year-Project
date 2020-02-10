using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HairPeaceWebsite.PeaceReference;

namespace HairPeaceWebsite
{
    public partial class WebCatalog : System.Web.UI.Page
    {
        HairServiceClient client = new HairServiceClient();

        private List<Prod> Prods;


        protected void Page_Load(object sender, EventArgs e)
        {
            client.IncrementTracking("Catalog");
            this.Prods = new List<Prod>();

            string Bfilter = Request.QueryString["BFilter"];
            string TypeFilter = Request.QueryString["TypeFilter"];
            int Filter = 0;
            Filter = Convert.ToInt32(Request.QueryString["Filter"]);
            int PFilter = 0;
            PFilter = Convert.ToInt32(Request.QueryString["PFilter"]);

            dynamic Products;
            if (Bfilter != null)
            {
                Products = client.fillByBrand(Bfilter);
            }
            else if (TypeFilter != null)
            {
                Products = client.fillByProdType(TypeFilter);
            }
            else if (PFilter != 0)
            {
                Products = client.fillByPrice(PFilter);
            }
            else if (Filter != 0)
            {
                Products = client.fillByDescOrder(Filter);
            }
            else
            {
                Products = client.prodList();
            }


            foreach (Prod c in Products)
            {
                Prods.Add(c);
            }

            B.InnerHtml = setUpBrands();
            Catalog.InnerHtml = Display(Prods);
        }

        private string Display(List<Prod> Product)
        {
            string display = "";
            foreach (Prod Prod in Product)
            {
                display += "<div class='col-sm col-md-6 col-lg-3 ftco-animate fadeInUp ftco-animated'>";
                display += "<div class='product'>";
                display += "<a href='productInfo.aspx?ID=" + Prod.ID + "' class='img-prod'><img class='img-fluid' src='" + Prod.Image + "' alt='Colorlib Template' style='width:400px;height:400px;'>";
                if (Prod.special.Equals(1))
                {
                    display += "<span class='status'>30%</span></a>";
                }
                display += "<div class='text py-3 px-3'>";
                display += "<h3>" + Prod.prodName + "</h3>";
                display += "<div class='d-flex'>";
                display += "<div class='pricing'>";
                if (Prod.special.Equals(1))
                {
                    display += "<p class='price'><span class='mr-2 price-dc'>$" + Math.Round(Prod.Price / 0.3, 2) + "</span><span class='price-sale'>$" + Math.Round(Prod.Price, 2) + "</span></p>";
                }
                else
                {
                    display += "<p class='price'><span class='price-sale'>$" + Math.Round(Prod.Price, 2) + "</span></p>";
                }

                display += "</div>";
                display += "</div>";
                if (Session["ID"] != null)
                {
                    String strID = Session["ID"].ToString();
                    display += "<hr>";
                    display += "<p class='bottom-area d-flex'>";
                    display += "<button type='button' style='postion:center;' class='btn btn-primary py-3 px-5' onclick='addCart(" + Prod.ID + "," + strID + ")'>Add to cart </button>";
                    display += "</p>";
                    //display += "<p id='" + Prod.ID + "Added'style='color:green; display:none;>Item Successfully added to cart!</p>";
                    //display += "<p id='" + Prod.ID + "NoAdd'style='color:red; display:none; postion:center;'>Item not added to cart!</p>";
                }
                display += "</div>";
                display += "</div>";
                display += "</div>";
            }
            return display;
        }

        private string setUpBrands()
        {
            dynamic p = client.htmlBrandFilter();
            string dis = "";
            foreach (string f in p)
            {
                dis += "<a class='dropdown-item' href='WebCatalog.aspx?BFilter=" + f + "'>" + f + "</a>";
            }
            return dis;
        }
    }
}