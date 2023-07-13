$(document).ready(function() {
    $('#showOrdersFivedays').addClass('active');
    $('.btn').on('click', function () {
        $('.btn').removeClass('active');
        $(this).addClass('active');
    });
});

window.onload=function(){
    $.ajax({
        type:"post",
        data:{number:"5"},
        url:"Order/showcurrent",
        success:function(data){
            $("#originalOrderPartial").html(data);
        },
    })
}
function upadtereview(){
    var orderDetailsReview = document.getElementsByClassName("orderDetailsReview");
    // var orderReviewOriginal = document.getElementsByClassName("orderReviewCSS");
    var orderupdate = [];
    for(var i = 0;i<orderDetailsReview.length;i++){
        if($.isNumeric($(".orderDetailsReview").eq(i).val())){
            var a = orderDetailsReview[i].getAttribute("ordername");
            var b = orderDetailsReview[i].getAttribute("ordertime");
            var c = $(".orderDetailsReview").eq(i).val();
            orderupdate.push(c,a,b);
        }
    }
    
    $.ajax({
        type:"post",
        url:"Order/UpdateReview",
        data:{details:orderupdate},
        success:function(){
            alert("Thank you for your review!");
            window.location.href="MyPurchase";
        }
    })
}

function showcurrentorder(i){
    var a = i.toString();
    $.ajax({
        type:"post",
        data:{number:i},
        url:"Order/showcurrent",
        success:function(data){ 
            $("#originalOrderPartial").html(data);
        },
    })
}