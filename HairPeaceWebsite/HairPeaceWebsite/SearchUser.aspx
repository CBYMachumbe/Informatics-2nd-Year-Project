<%@ Page Title="" Language="C#" MasterPageFile="~/HairPeace.Master" AutoEventWireup="true" CodeBehind="SearchUser.aspx.cs" Inherits="HairPeaceWebsite.SearchUser" %>
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
                    <h2 class="mb-5">Search User</h2>
                </div>
                <div class="form-group">
                  <label class="font-weight-bold">Email</label>
                <input type="text" id="email" class="form-control" runat="server">
              </div>
                
                
                <!--Changed Here -->
              <div class="form-group row justify-content-center">
                     <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn btn-primary py-3 px-5" OnClick="btnSearch_Click" />
                </div>
            </div>
          </div>
        </div>
      </div>

</asp:Content>
