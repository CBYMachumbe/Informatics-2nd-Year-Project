using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HairPeaceWebsite.PeaceReference;

namespace HairPeaceWebsite
{
    public partial class modifyUser : System.Web.UI.Page
    {
        HairServiceClient client = new HairServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            string Email = Request.QueryString["Email"];
            User user = client.GetAnonUser(Email);

            email.Value = user.email;
            name.Value = user.Name;
            surname.Value = user.surname;
            Usertype.Value = user.type;
            isActive.Value = Convert.ToString(user.active);

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string Email = Request.QueryString["Email"];
            User user = new User
            {
                Name = name.Value,
                surname = surname.Value,
                type = Usertype.Value,
                email = email.Value,
                active = Convert.ToInt32(isActive.Value)
            };

            int changed = client.editUser(user, Email);

            if(changed.Equals(1))
            {
                Response.Write("<script>window.alert('Changes Made Successfully!')</script>");
                Response.Redirect("Home.aspx");
            }
            else
            {
                messageDiv.Visible = true;
                message.Value = "Something Went Wrong Please Again Later";
            }

        }
    }
}