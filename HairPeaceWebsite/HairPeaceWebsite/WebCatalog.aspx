<%@ Page Title="" Language="C#" MasterPageFile="~/HairPeace.Master" AutoEventWireup="true" CodeBehind="WebCatalog.aspx.cs" Inherits="HairPeaceWebsite.WebCatalog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="hero-wrap hero-bread" style="background-image: url('images/bg_6.jpg');">
      <div class="container">
        <div class="row no-gutters slider-text align-items-center justify-content-center">
          <div class="col-md-9 ftco-animate text-center">
            <h1 class="mb-0">Collection</h1>
            <p class="breadcrumbs"><span class="mr-2"><a href="home.aspx">Home</a></span> <span>Product</span></p>
          </div>
        </div>
      </div>
    </div>
		

		<section class="ftco-section bg-light">
    	<div class="container-fluid">

            <!-- <div class="container">
				<div class="row justify-content-center mb-3 pb-3">
                    <div class="col-md-12 heading-section text-center ftco-animate">
          	            <h2 class="big">The Best</h2>
                        <h2 class="mb-4">Hair Products</h2>
                    </div>
                </div>    		
    	    </div> -->

            <div class="navbar navbar-expand-lg navbar-dark ftco_navbar bg-dark ftco-navbar-light" id="ftco-navbar">
	             <div class="container">
                    <div class="collapse navbar-collapse" id="ftco-nav">
	                    <ul class="navbar-nav ml-auto">
                            <li class="nav-item">
                                <a class="nav-link dropdown-toggle" href="#" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><span class="icon-filter"></span> Filter By :</a>
                                
                                    <div class="dropdown-menu" aria-labelledby="dropdown08">
                                        <a class="dropdown-item">Price :</a>
                                        <a class="dropdown-item" href="WebCatalog.aspx?PFilter=1">$0-$50</a>
                                        <a class="dropdown-item" href="WebCatalog.aspx?PFilter=2">$50-$100</a>
                                        <a class="dropdown-item" href="WebCatalog.aspx?PFilter=3">$100-$200</a>

                                        <a class="dropdown-item" style="color:deeppink">Name :</a>
                                        <a class="dropdown-item" href="WebCatalog.aspx?Filter=1">A-Z</a>
                                        <a class="dropdown-item" href="WebCatalog.aspx?Filter=2">Z-A</a>

                                        <a class="dropdown-item" style="color:deeppink">Brand :</a>
                                        <!--<div id="B" runat="server">
                                        </div>-->

                                        <a class="dropdown-item" style="color:deeppink">Type :</a>
                                        <a class="dropdown-item" href="WebCatalog.aspx?TypeFilter=Hair">Hair</a>
                                        <a class="dropdown-item" href="WebCatalog.aspx?TypeFilter=HairCare">Hair Care</a>

                                        <a class="dropdown-item lightSpeedIn" href="WebCatalog.aspx?Filter=20">On Special</a>

                                     </div>
                                </li>
	                        </ul>
	                    </div>
	                </div>
	            </div>

    		<div class="row" runat="server" id="Catalog">

    		</div>
    	</div>
    </section>

	<section class="ftco-section-parallax">
      <div class="parallax-img d-flex align-items-center">
        <div class="container">
          <div class="row d-flex justify-content-center py-5">
            <div class="col-md-7 text-center heading-section ftco-animate">
            	<h1 class="big">Subscribe</h1>
              <h2>Subcribe to our Newsletter</h2>
              <div class="row d-flex justify-content-center mt-5">
                <div class="col-md-8">
                  <div class="subscribe-form">
                    <div class="form-group d-flex">
                      <input type="text" class="form-control" placeholder="Enter email address">
                      <input type="submit" value="Subscribe" class="submit px-3">
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
</asp:Content>
