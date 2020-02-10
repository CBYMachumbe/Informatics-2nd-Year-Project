using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HairPeaceWebsite.PeaceReference;

namespace HairPeaceWebsite
{
    public partial class addProduct : System.Web.UI.Page
    {
        HairServiceClient client = new HairServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Prod Product = new Prod
            {
                prodName = pName.Value,
                prodType = pType.Value,
                sNumber = sNumber.Value,
                Price = Convert.ToDouble(pricr.Value),
                brand = bName.Value,
                special=Convert.ToInt32(special.Value),
                description =description.Value,
                Qty = Convert.ToInt32(Qty.Value),
                Image = image.Value,
                inStock = 1
            };

            if (Product != null)
            {
                bool check = client.appendNewProduct(Product);

                if (check == true)
                {
                    int id = client.searchProd(sNumber.Value);
                    Response.Redirect("productInfo.aspx?ID=" + id);
                }
                else
                {

                }

            }

        }
    }
}