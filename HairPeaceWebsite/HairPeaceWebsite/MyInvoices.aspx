<%@ Page Title="" Language="C#" MasterPageFile="~/HairPeace.Master" AutoEventWireup="true" CodeBehind="MyInvoices.aspx.cs" Inherits="HairPeaceWebsite.MyInvoices" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="ftco-section bg-light">
    	<div class="container-fluid">

            <div class="container">
				<div class="row justify-content-center mb-3 pb-3">
                    <div class="col-md-12 heading-section text-center ftco-animate">
          	            <h2 class="big">hairpeace</h2>
                        <h2 class="mb-4">Your Transaction History</h2>
                    </div>
                </div>    		
    	    </div>

    		<table class="table">
                <thead class="thead-primary">
                    <tr class="text-center">
                        <th>Product Name</th>
                        <th>Serial Number</th>
                        <th>Order ID</th>
                        <th>Quantity</th>
                        <th>Amount Paid</th>
                        <th>Date Purchase</th>
                    </tr>
                </thead>

                <tbody id="BoughtTings" runat="server">

                </tbody>     
           </table>
    	</div>
              <div>
                  <asp:Button ID="Button1" runat="server" Text="Go back home" class="btn btn-primary py-3 px-5" OnClick="home_Click" />
              </div>
    </section>


</asp:Content>
