using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HairPeaceWebsite.PeaceReference;

namespace HairPeaceWebsite
{
    public partial class CusInteractions : System.Web.UI.Page
    {
        HairServiceClient client = new HairServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            client.IncrementTracking("Tutorials");
            VidTings.InnerHtml = displayVidTings();
        }

        private string displayVidTings()
        {
            string display = "";

            display += "<tr>";
            display += "<td style='align-content:flex-start;'>";
            display += "<iframe src='https://www.youtube.com/watch?v=DwdRRoMHiJA' width='600' height='400' frameborder='0'></iframe></td>";
            display += "<td style='align-content:flex-end;'>";
            display += "<i><b><p>Name of Youtuber/Content Creator</p></b></i></p>";
            display += "<p>Product Used: <i><a href='ProductInfor.apsx'>Product Name</a></i></p>";
            display += "<p>Description of video & How Our Product Is Used!</p>";
            display += "</td></tr>";

            return display;
        }
    }
}