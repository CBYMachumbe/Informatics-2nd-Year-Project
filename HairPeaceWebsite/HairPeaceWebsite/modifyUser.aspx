<%@ Page Title="" Language="C#" MasterPageFile="~/HairPeace.Master" AutoEventWireup="true" CodeBehind="modifyUser.aspx.cs" Inherits="HairPeaceWebsite.modifyUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="ftco-section contact-section bg-light">
      <div class="container">
        <!--Changed Here -->
              <div class="form-group row justify-content-center">
          <div class="col-md-6 order-md-last d-flex">
            <div class="bg-white p-5 contact-form">
                <div class="site-section-heading text-center mb-5 w-border col-md-6 mx-auto">
                    <h2 class="mb-5">Change User Details</h2>
                </div>
                <div class="form-group">
                  <label class="font-weight-bold">Name</label>
                <input type="text" id="name" class="form-control" runat="server">
              </div>
                <div class="form-group">
                  <label class="font-weight-bold">Surname</label>
                <input type="text" id="surname" class="form-control" runat="server">
              </div>
              <div class="form-group">
                  <label class="font-weight-bold">Email</label>
                <input type="email" id="email" class="form-control" runat="server">
              </div>
              <div class="form-group" runat="server">
                  <label class="font-weight-bold">Activity</label>
                  <select id="isActive" class="form-control" runat="server">
                   <option value="">Is The User Active?</option>
		           <option value="1">Yes</option>
		           <option value="0">No</option>
		         </select>
              </div>
              <div class="form-group" runat="server">
                  <label class="font-weight-bold">Usertype</label>
                  <select id="Usertype" class="form-control" runat="server">
                   <option value="">Choose Usertype</option>
		           <option value="User">Customer</option>
		           <option value="Admin">Admin</option>
		          <option value="Manager">Manager</option>
		         </select>
              </div>
              <div class="form-group row justify-content-center">
                 <asp:Button ID="btnSubmit" runat="server" Text="Submit Changes" class="btn btn-primary py-3 px-5" OnClick="btnSubmit_Click" />
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
