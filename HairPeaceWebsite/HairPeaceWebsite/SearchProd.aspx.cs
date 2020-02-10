using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HairPeaceWebsite.PeaceReference;

namespace HairPeaceWebsite
{
    public partial class SearchProd : System.Web.UI.Page
    {
        HairServiceClient client = new HairServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearchID_Click(object sender, EventArgs e)
        {
          int prod = client.searchProd((prodID.Value));
            if (prod!=0)
            {
                Response.Redirect("EditProduct.aspx?ID=" + prod);
            }
            else {

                Response.Write("<script>window.alert(' Product Does Not Exist')</script>");
            }

            
        }
    }
}