using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HairPeaceWebsite.PeaceReference;



namespace HairPeaceWebsite
{
    public partial class Checkout : System.Web.UI.Page
    {
        HairServiceClient client = new HairServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            DisSplip.InnerHtml = displaySlip();
        }

        protected void btnPayment_Click(object sender, EventArgs e)
        {
            if (Terms.Checked)
            {
                Random rand = new Random();
                int order = rand.Next(100, 100001);

                /*while(client.OrderExists(order))
                {
                    order = rand.Next(100, 100001);
                }*/

                bDetails billing = new bDetails
                {
                    Name = name.Value,
                    Surname = surname.Value,
                    Email = email.Value,
                    Province = Province.Value,
                    House_Adress = HouseNum.Value,
                    City = TownCity.Value,
                    Street_Adress = street.Value,
                    ZIP = zip.Value,
                    Phone = phone.Value,
                    Order_ID = order,
                    User_ID = Convert.ToInt32(Session["ID"].ToString())
                };

                if (client.addDetails(billing) == 1)
                {


                    Prod prod = client.GetProd(getProdID());
                    double amountDue = Convert.ToDouble(Session["Total"].ToString());

                    Response.Write("<form action='https://www.sandbox.paypal.com/cgi-bin/webscr' method='post' name='buyCredits' id='buyCredit'>");
                    Response.Write("<input type='hidden' name='cmd' value='_xclick'>");
                    Response.Write("<input type='hidden' name='business' value='hair@peace.com'>");
                    Response.Write("<input type='hidden' name='currency_code' value='USD'>");
                    Response.Write("<input type='hidden' name='item_name' value='" + prod.prodName + "'>");
                    Response.Write("<input type='hidden' name='item_number' value='" + prod.ID + "'>");
                    Response.Write("<input type='hidden' name='amount' value='" + Convert.ToString(Math.Round(amountDue, 2)).Replace(",", ".") + "'>");
                    Response.Write("<input type='hidden' name='return' value='http://localhost:58955/Receipt.aspx?order=" + order + "'>");
                    Response.Write("</form>");

                    Response.Write("<script type='text/javascript'>");
                    Response.Write("document.getElementById('buyCredit').submit();");
                    Response.Write("</script>");

                }
            }
            else
            {
                System.Web.HttpContext.Current.Response.Write("<script>window.alert('Please Accept The Terms & Conditions')</script>");
            }

        }

        private string displaySlip()
        {
            string display = "";

            display += "<h3 class='billing-heading mb-4'>Cart Total</h3>";
            display += "<p class='d-flex'>";
            display += "<span>Subtotal</span>";
            display += "<span>$" + Session["SubTotal"].ToString() + "</span></p>";
            display += "<p class='d-flex'>";
            display += "<span>Delivery</span>";
            display += "<span>$" + Session["Delivery"].ToString() + "</span></p>";
            display += "<p class='d-flex'>";
            display += "<span>Discount</span>";
            display += "<span>$" + Session["Discount"].ToString() + "</span></p>";
            display += "<hr><p class='d-flex total-price'>";
            display += "<span>Total</span>";
            display += "<span>$" + Session["Total"].ToString() + "</span></p>";

            return display;
        }

        private int getProdID()
        {
            dynamic dyCart = client.GetCarts(Convert.ToInt32(Session["ID"].ToString()));
            int prodID = -1;
            foreach (userCart c in dyCart)
            {
                prodID = c.Prod_ID;
            }

            return prodID;
        }

    }
}