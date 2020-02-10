using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HairPeaceWebsite.PeaceReference;

namespace HairPeaceWebsite
{
    public partial class Register : System.Web.UI.Page
    {
        HairServiceClient client = new HairServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Usertype"] != null)
            {
                if (Session["Usertype"].ToString().Equals("Manager"))
                {
                    optUserType.Visible = true;
                }
            }
            
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            var reg = -4;
            if (userPassword.Value.Equals(confPass.Value))
            {
                User user;
                if (Session["Usertype"] != null) {
                    if (Session["Usertype"].ToString().Equals("Manager"))
                    {
                        user = new User
                        {
                            Name = name.Value,
                            surname = surname.Value,
                            email = email.Value,
                            pass = userPassword.Value,
                            active = 1,
                            type = Usertype.Value
                        };
                        reg = client.Register(user);
                    }
                } 
                else
                {
                    user = new User
                    {
                        Name = name.Value,
                        surname = surname.Value,
                        email = email.Value,
                        pass = userPassword.Value,
                        active = 1,
                        type = "User",
                     
                };
                  reg = client.Register(user);

                }

                

                
            }
            else
            {
                System.Web.HttpContext.Current.Response.Write("<script>window.alert('Password and confirm password do not match')</script>");
            }
            if (reg == 1)
            {
                Response.Redirect("Login.aspx");
            }
            else {
                Response.Write("<script>window.alert('reg:"+reg+"')</script>");
            }



        }
    }
}