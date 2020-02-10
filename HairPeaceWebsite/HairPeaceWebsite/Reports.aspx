<%@ Page Title="" Language="C#" MasterPageFile="~/HairPeace.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="HairPeaceWebsite.Reports" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <section class="ftco-section bg-light">
    	<div class="container-fluid">

            <div class="container">
				<div class="row justify-content-center mb-3 pb-3">
                    <div class="col-md-12 heading-section text-center ftco-animate">
          	            <h2 class="big">hairpeace</h2>
                        <h2 class="mb-4">Product Sold</h2>
                    </div>
                </div>    		
    	    </div>

    		<table class="table">
                <thead class="thead-primary">
                    <tr class="text-center">
                        <th>Product Name</th>
                        <th>Serial Number</th>
                        <th>Price</th>
                    </tr>
                </thead>

                <tbody id="ProductsSold" runat="server">

                    <tr class="text-center">
                        <td>
                            <div class="product-name">
                                <p>Name of Products</p>
                            </div>
                        </td>
                        <td class="price">AAA-BBB-CCC</td>
                        <td class="price">5</td>
                        
                    </tr>

                </tbody>     
           </table>
    	</div>
    </section>


    <section class="ftco-section bg-light">
    	<div class="container-fluid">

            <div class="container">
				<div class="row justify-content-center mb-3 pb-3">
                    <div class="col-md-12 heading-section text-center ftco-animate">
          	            <h2 class="big">hairpeace</h2>
                        <h2 class="mb-4">Inventory Control</h2>
                    </div>
                </div>    		
    	    </div>

    		<table class="table">
                <thead class="thead-primary">
                    <tr class="text-center">
                        <th>Product Name</th>
                        <th>Serial Number</th>
                        <th>Quantity</th>
                    </tr>
                </thead>

                <tbody id="Inventory" runat="server">

                    <tr class="text-center">
                        <td>
                            <div class="product-name">
                                <p>Name of Products</p>
                            </div>
                        </td>
                        <td class="price">AAA-BBB-CCC</td>
                        <td class="price">5</td>
                        
                    </tr>

                </tbody>     
           </table>
    	</div>
    </section>


    <section class="ftco-section bg-light">
    	<div class="container-fluid">

            <div class="container">
				<div class="row justify-content-center mb-3 pb-3">
                    <div class="col-md-12 heading-section text-center ftco-animate">
          	            <h2 class="big">hairpeace</h2>
                        <h2 class="mb-4">Number of registered users per day</h2>
                    </div>
                </div>    		
    	    </div>

            <div class="container">
				<div class="row justify-content-center mb-3 pb-3">
        <asp:Chart ID="Chart1" runat="server" Height="419px" OnLoad="Chart1_Load" Width="732px">
            <Series>
                <asp:Series Name="Series1" ChartArea="ChartArea1"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
            </div>
    	</div>

    	</div>
    </section>

    <section class="ftco-section bg-light">
    	<div class="container-fluid">

            <div class="container">
				<div class="row justify-content-center mb-3 pb-3">
                    <div class="col-md-12 heading-section text-center ftco-animate">
          	            <h2 class="big">hairpeace</h2>
                        <h2 class="mb-4">Active Vs. Inactive Users</h2>
                    </div>
                </div>    		
    	    </div>

            <div class="container">
				<div class="row justify-content-center mb-3 pb-3">
        <asp:Chart ID="Chart2" runat="server" Height="419px" OnLoad="Chart1_Load" Width="732px">
            <Series>
                <asp:Series Name="Series1" ChartArea="ChartArea1"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
            </div>
        </div>
    		
    	</div>
    </section>

    <section class="ftco-section bg-light">
    	<div class="container-fluid">

            <div class="container">
				<div class="row justify-content-center mb-3 pb-3">
                    <div class="col-md-12 heading-section text-center ftco-animate">
          	            <h2 class="big">hairpeace</h2>
                        <h2 class="mb-4">Pages Visits</h2>
                    </div>
                </div>    		
    	    </div>

            <div class="container">
				<div class="row justify-content-center mb-3 pb-3">
        <asp:Chart ID="Chart3" runat="server" Height="419px" OnLoad="Chart1_Load" Width="732px">
            <Series>
                <asp:Series Name="Series1" ChartArea="ChartArea1"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
            </div>
        </div>
    		
    	</div>
    </section>



</asp:Content>
