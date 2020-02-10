<%@ Page Title="" Language="C#" MasterPageFile="~/HairPeace.Master" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="HairPeaceWebsite.EditProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="ftco-section contact-section bg-light">
      <div class="container">
        <!--Changed Here -->
        <div class="row row justify-content-center">
          <div class="col-md-6 order-md-last d-flex">
            <div class="bg-white p-5 contact-form">
                <div class="site-section-heading text-center mb-5 w-border col-md-6 mx-auto">
                    <h2 class="mb-5">Edit Product</h2>
                </div>
                <div class="form-group">
                  <label class="font-weight-bold">Product Name</label>
                <input type="text" id="name" class="form-control" runat="server">
              </div>
                <div class="form-group">
                  <label class="font-weight-bold">Serial Number</label>
                <input type="text" id="sNumber" class="form-control" runat="server">
              </div>
              <div class="form-group">
                  <label class="font-weight-bold">Product Type</label>
                <input type="text" id="pType" class="form-control" runat="server">
              </div>
              <div class="form-group">
                  <label class="font-weight-bold">Price</label>
                <input type="text" id="prodPrice" class="form-control" runat="server">
              </div>
                <div class="form-group">
                  <label class="font-weight-bold">Quantity</label>
                <input type="text" id="quantity" class="form-control" runat="server">
              </div>
                <div class="form-group">
                  <label class="font-weight-bold">Brand</label>
                <input type="text" id="brand" class="form-control" runat="server">
              </div>
                <div class="form-group">
                  <label class="font-weight-bold">On Special?</label>
                <input type="text" id="productSpecial" class="form-control" runat="server">
              </div>
                <div class="form-group">
                  <label class="font-weight-bold">Product Description </label>
                <input type="text" id="description" class="form-control" runat="server">
              </div>
                <div class="form-group">
                  <label class="font-weight-bold">Product Image </label>
                <input type="text" id="image" class="form-control" runat="server">
              </div>

                <!--Changed Here -->
                <div class="row row justify-content-center">
                    <asp:Button ID="btnEdit" runat="server" Text="Edit" class="btn btn-primary py-3 px-5" OnClick="btnEdit_Click" />
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
