using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HairPeaceWebsite.PeaceReference;

namespace HairPeaceWebsite
{
    public partial class productInfo : System.Web.UI.Page
    {
        HairServiceClient client = new HairServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            client.IncrementTracking("ProductInfo");
            int id = Convert.ToInt32(Request.QueryString["ID"]);

            string display = "";

            Prod cl = client.GetProd(id);

            display += "<div class='row'>";
            display += "<div class='col-lg-6 mb-5 ftco-animate'>";
            display += "<a href='productInfo.aspx?ID=" + cl.ID + "' class='image-popup'><img src='" + cl.Image + "' class='img-fluid' alt='Colorlib Template'></a>";
            display += "</div>";
            display += "<div class='col-lg-6 product-details pl-md-5 ftco-animate'>";
            display += "<h3>" + cl.prodName + "</h3>";
            display += "<h5>" + cl.brand + "</h5>";
            display += "<p>" + cl.description + "</p>";
            display += "<h4 class='price'><span>R " + Math.Round(cl.Price, 2) + "</span></h4>";
            display += "<div class='row mt-4'>";
            display += "<div class='col-md-6'>";
            display += "<div class='form-group d-flex'>";
            display += "<div class='select-wrap'>";
            display += "<div class='icon'><span class='ion-ios-arrow-down'></span></div>";
            display += "</div>";
            display += "</div>";
            display += "</div>";
            //display += "<div class='w-100'></div>";
            //display += "<div class='input-group col-md-6 d-flex mb-3'>";
            //display += "<span class='input-group-btn mr-2'>";
            //display += "<button type='button' class='quantity-left-minus btn'  data-type='minus' data-field=''>";
            //display += "<i class='ion-ios-remove'></i>";
            //display += "</button>";
            //display += "</span>";
            //display += "<input type='text' id='quantity' name='quantity' class='form-control input-number' value='1' min='1' max='100'>";
            //display += "<span class='input-group-btn ml-2'>";
            //display += "<button type='button' class='quantity-right-plus btn' data-type='plus' data-field=''>";
            //display += " <i class='ion-ios-add'></i>";
            //display += " </button>";
            //display += "</span>";

            if (Session["ID"] != null)
            {
                String strID = Session["ID"].ToString();
                //display += "<p class='bottom-area d-flex'>";
                display += "<button type='button' class='btn btn-primary py-3 px-5'  style='postion:center;' onclick='addCart(" + cl.ID + "," + strID + ")'>Add to cart</button>";
                display += "</p>";
                //display += "<p id='" + cl.ID + "Added'style='color:green; display:none;>Item Successfully added to cart!</p>";
                //display += "<p id='" + cl.ID + "NoAdd'style='color:red; display:none; postion:center;'>Item not added to cart!</p>";
            }

            display += "</div>";
            display += "</div>";
            display += "</div>";
            AboutProduct.InnerHtml = display;
        }
    }
}