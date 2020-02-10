<%@ Page Title="" Language="C#" MasterPageFile="~/HairPeace.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="HairPeaceWebsite.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--Banner-->
    <div class="hero-wrap js-fullheight" style="background-image: url('images/images.jpg');">
      <div class="overlay"></div>
      <div class="container">
        <div class="row no-gutters slider-text js-fullheight align-items-center justify-content-center">
        	<h3 class="v">HairPeace - Quality Hair at a Quality Price</h3>
        	<h3 class="vr">Since - 2019</h3>
          <div class="col-md-11 ftco-animate text-center">
            <h1>Own Your Crown</h1>
            <h2><span>Love Your Hair</span></h2>
          </div>
          <div class="mouse">
			<a href="#" class="mouse-icon">
				<div class="mouse-wheel"><span class="ion-ios-arrow-down"></span></div>
			</a>
		   </div>
        </div>
      </div>
    </div>

    <div class="goto-here"></div>

    <section class="ftco-section ftco-no-pb ftco-no-pt bg-light">
			<div class="container">
				<div class="row">
					<div class="col-md-5 p-md-5 img img-2 d-flex justify-content-center align-items-center" style="background-image: url(images/index-beauty.jpg);">
						<!--<a href="https://vimeo.com/45830194" class="icon popup-vimeo d-flex justify-content-center align-items-center">
							<span class="icon-play"></span>
						</a>-->
					</div>
					<div class="col-md-7 py-5 wrap-about pb-md-5 ftco-animate">
	          <div class="heading-section-bold mb-5 mt-md-5">
	          	<div class="ml-md-0">
		            <h2 class="mb-4">HAIRPEACE <br>Online <br> <span>Hair Care Shop</span></h2>
	            </div>
	          </div>
	          <div class="pb-md-5">
							<p>Welcome to our haven of magnificent, luxurious hair. Get enticed by our customer satisfactory brands and prices. Dive into owning your own with desired styling youu can afford.</p>
							<p>Own your style for it defines you. Step into the journey of opulent shopping that fits into the category of your needs and desires. Now enter into this glamarous world...</p>
                            <h2>Own Your Crown - Love Your Hair!!
                            </h2>
						</div>
					</div>
				</div>
			</div>
		</section>

    <!--Product Display-->
    <section class="ftco-section bg-light">
        <div class="container">
				<div class="row justify-content-center mb-3 pb-3">
          <div class="col-md-12 heading-section text-center ftco-animate">
          	<h1 class="big">Products</h1>
            <h2 class="mb-4">Our Products</h2>
          </div>
        </div>    		
    	</div>

        <div class="container-fluid">
    		<div class="row" runat="server" id="Catalog">
            </div>
        </div>
    </section>

    <section class="ftco-section bg-light ftco-services">
    	<div class="container">
    		<div class="row justify-content-center mb-3 pb-3">
          <div class="col-md-12 heading-section text-center ftco-animate">
            <h1 class="big">Services</h1>
            <h2>We want you to express yourself</h2>
          </div>
        </div>
        <div class="row">
          <div class="col-md-4 text-center d-flex align-self-stretch ftco-animate">
            <div class="media block-6 services">
              <div class="icon d-flex justify-content-center align-items-center mb-4">
            		<span class="flaticon-002-recommended"></span>
              </div>
              <div class="media-body">
                <h3 class="heading">Refund Policy</h3>
                <p>We Refund As Along As The Product Is Not Used.</p>
              </div>
            </div>      
          </div>
          <div class="col-md-4 text-center d-flex align-self-stretch ftco-animate">
            <div class="media block-6 services">
              <div class="icon d-flex justify-content-center align-items-center mb-4">
            		<span class="flaticon-001-box"></span>
              </div>
              <div class="media-body">
                <h3 class="heading">Premium Packaging</h3>
                <p>Your Order Reaches Your Person Without Dents Or Scrathes.</p>
              </div>
            </div>    
          </div>
          <div class="col-md-4 text-center d-flex align-self-stretch ftco-animate">
            <div class="media block-6 services">
              <div class="icon d-flex justify-content-center align-items-center mb-4">
            		<span class="flaticon-003-medal"></span>
              </div>
              <div class="media-body">
                <h3 class="heading">Superior Quality</h3>
                <p>Quality Hair Products At A Quality Price.</p>
              </div>
            </div>      
          </div>
        </div>
    	</div>
    </section>

</asp:Content>
