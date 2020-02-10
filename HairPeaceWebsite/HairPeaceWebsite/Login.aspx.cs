using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HairPeaceWebsite.PeaceReference;

namespace HairPeaceWebsite
{
    public partial class Login : System.Web.UI.Page
    {
        HairServiceClient client = new HairServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            /*var access = client.Login("q@t.com", "123");
            if (access == true)
            {
                User u = client.GetUser("q@t.com", "123");
                Session["UserType"] = u.type;
                Session["Email"] = u.email;
                Session["Password"] = "123";
                Session["ID"] = u.ID;
                client.UserLoggings(u.ID);
                Response.Redirect("Home.aspx");
             
            }*/
            

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var access = client.Login(email.Value, userPassword.Value);

            if (access == true)
            {
                User u = client.GetUser(email.Value, userPassword.Value);
                Session["UserType"] = u.type;
                Session["Email"] = u.email;
                Session["Password"] = userPassword.Value;
                Session["ID"] = u.ID;
                client.UserLoggings(u.ID);
                Response.Redirect("Home.aspx");
            }
            else
            {
                messageDiv.Visible = true;
                message.Value = "Incorrect Email or Password";

            }

        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}