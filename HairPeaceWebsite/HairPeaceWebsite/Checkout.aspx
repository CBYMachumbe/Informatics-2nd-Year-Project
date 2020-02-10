<%@ Page Title="" Language="C#" MasterPageFile="~/HairPeace.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="HairPeaceWebsite.Checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="hero-wrap hero-bread" style="background-image: url('images/bg_6.jpg');">
        <div class="container">
        <div class="row no-gutters slider-text align-items-center justify-content-center">
            <div class="col-md-9 ftco-animate text-center">
            <h1 class="mb-0">Checkout</h1>
            <p class="breadcrumbs"><span class="mr-2"><a href="Home.apsx">Home</a></span> <span>Checkout</span></p>
            </div>
        </div>
        </div>
    </div>
		
	    <section class="ftco-section">
        <div class="container">
        <div class="row justify-content-center">
            <div class="col-xl-8 ftco-animate">
					    <form action="#" class="billing-form bg-light p-3 p-md-5">
						    <h3 class="mb-4 billing-heading">Billing Details</h3>
	            <div class="row align-items-end">
	          	    <div class="col-md-6">
	                <div class="form-group">
	                    <label for="firstname">First Name</label>
	                    <input type="text" class="form-control" placeholder="" id="name" runat="server">
	                </div>
	                </div>
	                <div class="col-md-6">
	                <div class="form-group">
	                    <label for="lastname">Last Name</label>
	                    <input type="text" class="form-control" placeholder="" id="surname" runat="server">
	                </div>
                </div>
                <div class="w-100"></div>
		            <div class="col-md-12">
		                <div class="form-group">
		            	    <label for="country">State / Country</label>
		            	    <div class="select-wrap">
		                    <div class="icon"><span class="ion-ios-arrow-down"></span></div>
		                    <select name="" id="Province" class="form-control" runat="server">
                                <option value="">Select Province</option>
		                        <option value="Gauteng">Gauteng</option>
		                        <option value="FState">Free State</option>
		                        <option value="Limpopo">Limpopo</option>
		                        <option value="KZN">KZN</option>
		                        <option value="Mpumalanga">Mpumalanga</option>
		                        <option value="ECape">Eastern Cape</option>
                                <option value="WCape">Western Cape</option>
                                <option value="NCape">Northern Cape</option>
		                    </select>
		                </div>
		                </div>
		            </div>
		            <div class="w-100"></div>
		            <div class="col-md-6">
		                <div class="form-group">
	                    <label for="streetaddress">Street Address</label>
	                    <input type="text" class="form-control" placeholder="House number and street name" id="HouseNum" runat="server">
	                </div>
		            </div>
		            <div class="col-md-6">
		                <div class="form-group">
	                    <input type="text" class="form-control" placeholder="Appartment, suite, unit etc: (optional)" runat="server" id="street" />
	                </div>
		            </div>
		            <div class="w-100"></div>
		            <div class="col-md-6">
		                <div class="form-group">
	                    <label for="towncity">Town / City</label>
	                    <input type="text" class="form-control" placeholder="" id="TownCity" runat="server">
	                </div>
		            </div>
		            <div class="col-md-6">
		                <div class="form-group">
		            	    <label for="postcodezip">Postcode / ZIP *</label>
	                    <input type="text" class="form-control" placeholder="" id="zip" runat="server">
	                </div>
		            </div>
		            <div class="w-100"></div>
		            <div class="col-md-6">
	                <div class="form-group">
	                    <label for="phone">Phone</label>
	                    <input type="text" class="form-control" placeholder="" id="phone" runat="server">
	                </div>
	                </div>
	                <div class="col-md-6">
	                <div class="form-group">
	                    <label for="emailaddress">Email Address</label>
	                    <input type="email" class="form-control" placeholder="" id="email" runat="server">
	                </div>
                </div>
                <div class="w-100"></div>
	            </div>
	            </form>

	            <div class="row mt-5 pt-3 d-flex">
	            <div class="col-md-6 d-flex">
	          	    <div class="cart-detail cart-total bg-light p-3 p-md-4" runat="server" id="DisSplip">
	          		    
					</div>
	            </div>
	            <div class="col-md-6">
	          	    <div class="cart-detail bg-light p-3 p-md-4">
                          <h3 class="billing-heading mb-4">Place Your Order</h3>
                                <div class="form-group">
								    <div class="col-md-12">
									    <div class="checkbox">
											 <label><input type="checkbox" class="mr-2"  id="Terms" runat="server"/> I Have Read and Accept The <a href="TCs.aspx">Terms & Conditions.</a></label>
									     </div>
									</div>
							     </div>
                            <asp:Button ID="order" runat="server" Text="Order" class="btn btn-primary py-3 px-4" OnClick="btnPayment_Click" />
						</div>
	                </div>
	            </div>
            </div>
       
        </div>
        </div>

    </section>
</asp:Content>
