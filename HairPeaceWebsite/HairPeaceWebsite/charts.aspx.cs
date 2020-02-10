using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;

namespace HairPeaceWebsite
{
    public partial class charts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadTings();
        }

        void loadTings()
        {
            string[] x = new string[5];
            int[] y = new int[5];

            for (int i = 0; i < x.Length; i++)
            {
                x[i] = "Item : " + i;
                y[i] = 10 + i;
            }

            Chart1.Series[0].Points.DataBindXY(x, y);
            Chart1.Series[0].ChartType = SeriesChartType.Pie;
        }
    }
}