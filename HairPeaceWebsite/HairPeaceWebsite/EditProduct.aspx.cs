using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HairPeaceWebsite.PeaceReference;

namespace HairPeaceWebsite
{
    public partial class EditProduct : System.Web.UI.Page
    {
        HairServiceClient client = new HairServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {


                int id = Convert.ToInt32(Request.QueryString["ID"]);

                Prod p = client.GetProd(id);
                name.Value = p.prodName;

                pType.Value = p.prodType;
                sNumber.Value = p.sNumber;
                prodPrice.Value = Convert.ToString(p.Price);

                brand.Value = p.brand;

                productSpecial.Value = Convert.ToString(p.special);
                description.Value = p.description;
                quantity.Value = Convert.ToString(p.Qty);
                image.Value = p.Image;

            }


        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {


            Prod p = new Prod
            {
                prodName = name.Value,
                prodType = pType.Value,
                sNumber = sNumber.Value,
                Price = Convert.ToDouble(prodPrice.Value),
                brand = brand.Value,
                special = Convert.ToInt32(productSpecial.Value),
                description = description.Value,
                Qty = Convert.ToInt32(quantity.Value),
                Image = image.Value

            };
            int id = Convert.ToInt32(Request.QueryString["ID"]);
            bool edit = client.modifyProd(p, Convert.ToInt32(id));

            if (edit == true)
            {
                Response.Write("<script>window.alert('Changes Made Successfully!')</script>");
                Response.Redirect("productInfo.aspx?ID=" + id);

            }
            else
            {
                messageDiv.Visible = true;
                message.Value = "Something Went Wrong Please Again Later";
            }
        }
    }
}