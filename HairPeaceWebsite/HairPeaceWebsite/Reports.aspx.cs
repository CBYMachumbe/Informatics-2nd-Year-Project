using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using HairPeaceWebsite.PeaceReference;

namespace HairPeaceWebsite
{
    public partial class Reports : System.Web.UI.Page
    {
        HairServiceClient client = new HairServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            dynamic prods = client.prodList();

            string display = "";

            foreach (Prod p in prods)
            {
                display += "<tr class='text-center'><td>";
                display += "<div class='product-name'>";
                display += "<p>" + p.prodName + "</p></div>";//Name
                display += "</td><td class='price'>" + p.sNumber + "</td>";//Serial Number
                display += "<td class='price'>" + p.Qty + "</td>";//Quantity
                display += "</tr>";
            }

            string inStock = "";

            foreach (Prod p in prods)
            {
                if(p.Qty > 0)
                {
                    inStock += "<tr class='text-center'>";
                    inStock += "<td><div class='product-name'>";
                    inStock += "<p>" + p.prodName + "</p></div></td>";//Name
                    inStock += "<td class='price'>" + p.sNumber + "</td>";//Serial Number
                    inStock += "<td class='price'>R" + Math.Round(p.Price, 2) + "</td></tr>";//Price
                }
            }

            Inventory.InnerHtml = display;
            ProductsSold.InnerHtml = inStock;
            loadChart();
            loadUsersChart();
            loadPageTings();
        }

        void loadChart()
        {

            List<cLogInDays> lDays = new List<cLogInDays>();
                var D= client.Days();
            foreach (cLogInDays p in D) {
                lDays.Add(p);
            }
            string[] x = new string[lDays.Count];
            int[] y = new int[lDays.Count];

            for (int i = 0; i < lDays.Count; i++) {
                x[i] = D[i].strDate;

            }
            for (int i = 0; i < lDays.Count; i++)
            {
                y[i] = D[i].intNumberOfLogins;
            }
            
            
            Chart1.Series[0].Color = Color.LightPink;
            Chart1.ChartAreas[0].AxisX.Title = "Days";
            Chart1.ChartAreas[0].AxisY.Title = "Number of Users";
           
            Chart1.ChartAreas[0].AxisX.TitleForeColor = Color.LightPink;
            Chart1.ChartAreas[0].AxisY.TitleForeColor = Color.LightPink;

           
            Chart1.ChartAreas[0].AxisY.TitleForeColor = Color.LightPink;

            Chart1.Series[0].Points.DataBindXY(x, y);
            Chart1.Series[0].ChartType = SeriesChartType.StackedColumn;
        }

        void loadUsersChart()
        {
            string[] x = new string[2];
            int[] y = new int[2];

            
            //int the y array put in the values from the database in order
            y[0] = client.ActiveUsers();
            y[1] = client.InactiveUsers();
            

            x[0] = "Active";
            x[1] = "Inactive";

            Chart2.Series[0].Color = Color.LightPink;
            
            Chart2.ChartAreas[0].Name = "Active Users Vs. Inactive Users";
            Chart2.ChartAreas[0].AxisX.TitleForeColor = Color.LightPink;
            Chart2.ChartAreas[0].AxisY.TitleForeColor = Color.LightPink;

            Chart2.Series[0].Points.DataBindXY(x, y);
            Chart2.Series[0].ChartType = SeriesChartType.Pie;
        }

        void loadPageTings()
        {
            string[] x = new string[7];
            int[] y = new int[7];

            x[0] = "Catalog";
            x[1] = "Invoices";
            x[2] = "Cart";
            x[3] = "Tutorials";
            x[4] = "About";
            x[5] = "Contact";
            x[6] = "Product Information";

            //int the y array put in the values from the database in order
            dynamic data = client.getTracking();
            int i = 0;
            foreach(PTracking p in data)
            {
                y[i] = p.nVisists;
                i++;

            }

            Chart3.Series[0].Color = Color.LightPink;
            Chart3.ChartAreas[0].AxisX.Title = "Page Visited";
            Chart3.ChartAreas[0].AxisY.Title = "Number of Users";

            Chart3.ChartAreas[0].AxisX.TitleForeColor = Color.LightPink;
            Chart3.ChartAreas[0].AxisY.TitleForeColor = Color.LightPink;


            Chart3.ChartAreas[0].AxisY.TitleForeColor = Color.LightPink;

            Chart3.Series[0].Points.DataBindXY(x, y);
            Chart3.Series[0].ChartType = SeriesChartType.StackedColumn;
        }

        protected void Chart1_Load(object sender, EventArgs e)
        {
        }

        protected void Chart1_CustomizeLegend(object sender, CustomizeLegendEventArgs e)
        {
        }
    }
}