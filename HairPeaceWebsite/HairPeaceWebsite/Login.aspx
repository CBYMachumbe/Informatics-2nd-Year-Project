<%@ Page Title="" Language="C#" MasterPageFile="~/HairPeace.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HairPeaceWebsite.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--Login Contents  -->
    
    <section class="ftco-section contact-section bg-light">
      <div class="container">
           <!--Changed Here -->
        <div class="row row justify-content-center">
          <div class="col-md-6 order-md-last d-flex">
            <div class="bg-white p-5 contact-form">
                <div class="site-section-heading text-center mb-5 w-border col-md-6 mx-auto">
                    <h2 class="mb-5">Login</h2>
                </div>
                <div class="form-group row justify-content-center">
                <p>Not Registered? Click <a href="Register.aspx">Here</a></p>
               </div>
              <div class="form-group">
                  <label class="font-weight-bold">Email</label>
                <input type="email" id="email"  class="form-control" runat="server">
              </div>
              <div class="form-group">
                  <label class="font-weight-bold">Password</label>
                <input type="password" id="userPassword" class="form-control" runat="server">
              </div>
                <!--Changed Here -->
              <div class="form-group row justify-content-center">
                <asp:Button ID="btnLogin" runat="server" Text="Login" class="btn btn-primary py-3 px-5" OnClick="btnLogin_Click"/>
              </div>

                <div class="row form-group" visible="false" runat="server" id="messageDiv">
                    <div class="col-md-12">
                        <label class="font-weight-bold" for="message">Message</label>
                        <textarea name="message" id="message" cols="30" rows="2" class="form-control" placeholder="" runat="server"></textarea>
                    </div>
                </div>
                
            </div>
          </div>
        </div>
      </div>
    </section>
</asp:Content>
