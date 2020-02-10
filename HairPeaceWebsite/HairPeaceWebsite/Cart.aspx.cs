using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HairPeaceWebsite.PeaceReference;



namespace HairPeaceWebsite
{
    public partial class Cart : System.Web.UI.Page
    {
        int nProds = 0;
        double subtotal = 0;
        double discount = 0;
        double delivery = 0;
        double total = 0;

        HairServiceClient client = new HairServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            client.IncrementTracking("Cart");
            List<userCart> cart = new List<userCart>();
            dynamic dyCart = client.GetCarts(Convert.ToInt32(Session["ID"].ToString()));

            foreach (userCart c in dyCart)
            {
                cart.Add(c);
            }

            CartEntries.InnerHtml = displayCartTable(cart);
            cartReciept.InnerHtml = displaySlip();

        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            Session["SubTotal"] = Math.Round(subtotal, 2);
            Session["Delivery"] = Math.Round(delivery, 2);
            Session["Discount"] = Math.Round(discount, 2);
            Session["Total"] = Math.Round(total, 2);
            Response.Redirect("Checkout.aspx");
        }

        private string displayCartTable(List<userCart> cart)
        {
            string display = "";

            foreach (userCart c in cart)
            {
                Prod pod = client.GetProd(Convert.ToInt32(c.Prod_ID));
                double total = 0;
                total += c.Quantity * pod.Price;
                subtotal += total;
                nProds++;

                display += "<tr class='text-center' id='" + c.Prod_ID + "row'>";
                display += "<td class='product-remove'><a type='button' onclick='remove(" + c.Prod_ID + "," + c.User_ID + ")'><span class='ion-ios-close'></span></a></td>";
                display += "<td class='image-prod'><div class='img' style='background-image:url(" + pod.Image + ")'></div></td>";
                display += "<td class='product-name'>";
                display += "<h3>" + pod.prodName + "</h3>";
                display += "<p>" + pod.description + "</p>";
                display += "</td>";
                display += "<td  class='price'><input id='" + c.Prod_ID + "price' value='" + Math.Round(pod.Price, 2) + "' " +
                    "style='display:none;'>$ " + Math.Round(pod.Price, 2) + "</td>";
                display += "<td class='quantity'>";
                display += "<div class='input-group mb-3'>";
                display += "<p class='text-center'><a onclick='decreasingQ(" + c.Prod_ID + "," + c.User_ID + ")' class='btn btn-primary py-3 px-4'> - </a></p>";
                display += "<input type='text' id='" + c.Prod_ID + "' readonly='readonly'  name='quantity' class='quantity form-control input-number' value='" + c.Quantity + "' min='1' max='100'>" +
                           "<p class='text-center'><a onclick='increasingQ(" + c.Prod_ID + "," + c.User_ID + ")' class='btn btn-primary py-3 px-4'> + </a></p></div></td>";
                display += "<td id='" + c.Prod_ID + "total' class='total'>$ " + Math.Round(total, 2) + "</td></tr>";

            }

            return display;
        }

        private string displaySlip()
        {
            discount = subtotal * 0.1;
            if (nProds < 10)
            {
                delivery = 100;
            }
            else
            {
                delivery = (nProds / 3) * 100;
            }

            total = subtotal + delivery - discount;

            string display = "";
            display += "<input id='nProd' style='display:none' value='" + nProds + "'>";
            display += "<input id='subTotal' style='display:none'value='" + subtotal + "'>";
            display += "<input id='dis' style='display:none'value='" + discount + "'>";
            display += "<input id='del' style='display:none'value='" + delivery + "'>";
            display += "<h3>Cart Totals</h3>";
            display += "<p class='d-flex'>";
            display += "<span>Subtotal</span>";
            display += "<span id='d2Subtotal'>$ " + Math.Round(subtotal, 2) + "</span></p>";
            display += "<p class='d-flex'>";
            display += "<span>Delivery</span>";
            display += "<span id='dDel'>$" + Math.Round(delivery, 2) + "</span></p>";
            display += "<p class='d-flex'>";
            display += "<span id='dDis'>Discount</span>";
            display += "<span>$ " + Math.Round(discount, 2) + "</span></p><hr>";
            display += "<p class='d-flex total-price'>";
            display += "<span>Total</span>";
            display += "<span id='mTotal'>$ " + Math.Round(total, 2) + "</span></p>";
            return display;
        }

    }
}