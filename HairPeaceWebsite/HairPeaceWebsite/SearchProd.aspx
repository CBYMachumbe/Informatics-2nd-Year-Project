<%@ Page Title="" Language="C#" MasterPageFile="~/HairPeace.Master" AutoEventWireup="true" CodeBehind="SearchProd.aspx.cs" Inherits="HairPeaceWebsite.SearchProd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="ftco-section contact-section bg-light">
      <div class="container">
        <div class="row row justify-content-center">
          <div class="col-md-6 order-md-last d-flex">
            <div class="bg-white p-5 contact-form">
                <div class="site-section-heading text-center mb-5 w-border col-md-6 mx-auto">
                    <h2 class="mb-5">Search Product</h2>
                </div>
              <div class="form-group">
                  <label class="font-weight-bold">Product Serial-Number:</label>
                <input type="text" id="prodID" class="form-control" runat="server">
              </div>
              <div class="row row justify-content-center">
                <asp:Button ID="btnSearchID" runat="server" Text="Search" class="btn btn-primary py-3 px-5" OnClick="btnSearchID_Click" />
              </div>
            </div>
          </div>
        </div>
    </div>
    </section>

</asp:Content>
