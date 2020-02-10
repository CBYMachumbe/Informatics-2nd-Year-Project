function increasingQ(pID,uID){
  
    AjaxHRService.ajaxCartI(pID, uID, OnSuccess);
    function OnSuccess(result) {
       // var a = result;
        $('#' + pID + '').val('' + result + '');
      //  var price = parseFloat($('#' + pID + 'price').val());
       // console.log(price);
       //price
       // console.log("T" + price+" r: "+result);
      //  $('#' + pID + 'total').text('R ' + price.toFixed(2) + '');
       // sTotal = sTotal - (price * (result - 1));
        
       

    }
    AjaxHRService.ajaxCartT(uID, OnDone);
    function OnDone(result) {
        $("#CartIcon").html('<span class="icon-shopping_cart"></span>[' + result + ']');
    }
   
}
function decreasingQ(pID, uID) {
    console.log("Start");
    AjaxHRService.ajaxCartD(pID, uID, OnSuccess);
    function OnSuccess(result) {
        if (result == 0) {
            remove(pID, uID)
        }
        else
            $('#' + pID + '').val('' + result + '');
        var price = $('#' + pID + 'price').val();
        price = price * result;
       // $('#' + pID + 'total').text('R ' + price + '');
    }
    AjaxHRService.ajaxCartT(uID, OnDone);
    function OnDone(result) {
        $("#CartIcon").html('<span class="icon-shopping_cart"></span>[' + result + ']');
    }
    
}
function addCart(pID, uID) {
    AjaxHRService.ajaxCartA(pID, uID, OnSuccess);
    function OnSuccess(result) {
        if (result) {
            $('.' + pID + 'Added').fadeIn();
            AjaxHRService.ajaxCartT(uID, OnDone);
            function OnDone(result) {
                $("#CartIcon").html('<span class="icon-shopping_cart"></span>[' + result + ']');
            }
            $('.' + pID + 'Added').fadeOut("slow");
        }
        else {
            $('.' + pID + 'NoAdd').fadeIn();
            $('.' + pID + 'NoAdd').fadeOut("Slow");
        }
        
        } 
        }
function remove(pID, uID) {
    AjaxHRService.ajaxRemove(pID, uID, OnS) 
    function OnS(result) {
        if (result) {
            $("#" + pID + "row").html("<td></td><td></td><td></td><td><p style='color:red; display:right; font-size:30px'>Item removed from the cart<p/></td>");
            AjaxHRService.ajaxCartT(uID, OnDone);
            function OnDone(result) {
                $("#CartIcon").html('<span class="icon-shopping_cart"></span>[' + result + ']');
            }
            $("#" + pID + "row").fadeOut("slow");
        }
        else {
            console.log("Unlucky bro");
        }
    }
}
