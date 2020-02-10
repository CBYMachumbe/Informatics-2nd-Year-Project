using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HairPeaceWebsite.PeaceReference;

namespace HairPeaceWebsite
{

    public partial class Receipt : System.Web.UI.Page
    {
        HairServiceClient client = new HairServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            int order = Convert.ToInt32(Request.QueryString["order"]);
            //int order = 13757;
            List<userCart> cart = new List<userCart>();
            dynamic dyCart = client.GetCarts(Convert.ToInt32(Session["ID"].ToString()));
            
            foreach (userCart c in dyCart)
            {
                cart.Add(c);
            }

            foreach (userCart c in cart)
            {

                tHistory transaction = new tHistory
                {
                    Prod_ID = c.Prod_ID,
                    Quantity = c.Quantity,
                    Order_ID = order,
                    Date = DateTime.Now
                };

                client.AddTransaction(transaction);
                //RemoveFrom DataBase
                client.TransactionTings(c.Prod_ID, c.Quantity);
            }

            client.ClearCart(Convert.ToInt32(Session["ID"].ToString()));

            List<tHistory> histories = new List<tHistory>();
            dynamic tings = client.getInvoice(order);
            bDetails details = client.getBillDetail(order);


            foreach(tHistory t in tings)
            {
                histories.Add(t);
            }

            PersonalDetails.InnerHtml = displayPersonalDetails(details);
            BoughtTings.InnerHtml = displayBoughtTings(histories);
            TaxTings.InnerHtml = displayTaxTings();
        }


        private string displayPersonalDetails(bDetails details)
        {
            string display = "";

            display += "<p class='solid'>HairPeace Order Number: " + details.Order_ID + "</p><p>";
            display += "Bill To: " + details.Name + " " + details.Surname;
            display += "<br>" + details.House_Adress + ", " + details.Street_Adress;
            display += "<br>" + details.City + ", " + details.Province;
            display += "<br>Phone: " + details.Phone;
            display += "<br>Email: " + details.Email + "</p>";

            return display;
        }

        private string displayBoughtTings(List<tHistory> histories)
        {
            string display = "";

            foreach (tHistory t in histories)
            {
                Prod prod = client.GetProd(t.Prod_ID);

                display += "<tr class='text-center'>";
                display += "<td class='image-prod'><div class='img' style='background-image:url(" + prod.Image + ");'></div></td>";
                display += "<td class='product-name'>";
                display += "<h3>" + prod.prodName + "</h3>";
                display += "<p>" + prod.description + "</p></td>";
                display += "<td class='price'>" + prod.sNumber + "</td>";
                display += "<td class='price'>" + t.Quantity + "</td>";
                display += "<td class='price'>R" + Math.Round(Convert.ToDouble(t.Quantity * prod.Price), 2) + "</td></tr>";
            }

            return display;
        }

        private string displayTaxTings()
        {
            string display = "";

            display += "<p>Date: " + DateTime.Now + "<br>";
            display += "Tax Total: R " + (Convert.ToDouble(Session["Total"].ToString()) * 0.15) + "<br>";
            display += "Sub Total: R " + Session["Total"].ToString() + "</p>";

            return display;
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}