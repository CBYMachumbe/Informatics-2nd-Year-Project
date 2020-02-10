using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HairPeaceWebsite.PeaceReference;

namespace HairPeaceWebsite
{
    public partial class MyInvoices : System.Web.UI.Page
    {
        HairServiceClient client = new HairServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            client.IncrementTracking("Invoices");
            dynamic tings = client.getInvoices(Convert.ToInt32(Session["ID"].ToString()));

            string display = "";

            foreach(tHistory t in tings)
            {
                Prod p = client.GetProd(t.Prod_ID);

                display += "<tr class='text-center'>";
                display += "<td class='product-name'>";
                display += "<h3>" + p.prodName + "</h3></td>";
                display += "<td class='price'>" + p.sNumber + "</td>";
                display += "<td class='price'>" + t.Order_ID + "</td>";
                display += "<td class='price'>" + t.Quantity + "</td>";
                display += "<td class='price'>R " + Math.Round((t.Quantity * p.Price),2) + "</td>";
                display += "<td class='total'>" + t.Date.Day + "/" + t.Date.Month + "/" + t.Date.Year + "</td></tr>";
            }

            BoughtTings.InnerHtml = display;
        }
        protected void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}