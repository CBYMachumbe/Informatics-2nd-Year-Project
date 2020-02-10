<%@ Page Title="" Language="C#" MasterPageFile="~/HairPeace.Master" AutoEventWireup="true" CodeBehind="Receipt.aspx.cs" Inherits="HairPeaceWebsite.Receipt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/hairpeace.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="ftco-section">
                <div class="container">
                    
				    <div class="row justify-content-center mb-3 pb-3">
                        <div class="col-md-12 heading-section text-center ftco-animate">
          	                <h1 class="big">HAIRPEACE</h1>
                            <h2 class="mb-4">Receipt</h2>
                        </div>
                    </div>    		
                    <div class="row justify-content-center">
                        <div class="col-xl-8 ftco-animate">
                            <div class="ex2" runat="server" id="PersonalDetails" style="width:50%; height:50%; float:left;">
                            </div>
                        
                        <div class="ex2"; style="width:50%; height:50%;float:left;">
                        </div>

                        <table class="table">
                            <thead class="thead-primary">
                                <tr class="text-center">
                                    <th>&nbsp;</th>
						            <th>&nbsp;</th>
                                    <th>Serial Number</th>
                                    <th>Quantity</th>
                                    <th>Total</th>
                                </tr>
                            </thead>

                            <tbody id="BoughtTings" runat="server" >
                            </tbody>     
                        </table>

                        </div>
                        <div runat="server" id="TaxTings" style="text-align:right; float:left">
                             
                         </div>
                        
                </div>
                    <div class="row justify-content-center">
                    <asp:Button ID="btnHome" class='btn btn-primary py-3 px-5' runat="server" Text="Back Home" OnClick="btnHome_Click" />
           </div>
                        </div>
        </section>


</asp:Content>
