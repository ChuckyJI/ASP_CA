// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
window.onload=function(){
    $.ajax({
        type:"post",
        url:"Login/layoutOnLoad",
        data:{},
        success:function(result){
            $("#containThePartialforLogin").html(result);
        }
    })
}


var clickTime = 0;
function addTheCart(i){
    $.ajax({
        type:"post",
        url:"Cart",
        data:{
            itemnamedisplay:document.getElementsByClassName("itemnamedisplay")[i].innerHTML,
        },
        success:function(){
            clickTime++;
        }
    });
    
    setInterval(function(){
        var numberOfCart = document.getElementById("numberOfCart");
        var cartRemaining = parseInt(document.getElementById("cartRemaining").innerHTML);
        var totalRemaining = cartRemaining+clickTime;
        numberOfCart.innerHTML = totalRemaining;
    },50);
}

function searchContent(){
    var inputcontent = $("#inputSearch").val();
    $.ajax({
        type:"post",
        url:"Home/SearchContent",
        data:{content : inputcontent},
        success:function (result){
            $("#containThePartial").html(result);
            $("#originalContent").hide();
        }
    })
}

function logout(){
    $.ajax({
        type:"post",
        url:"Order/EmptyCart",
        success:function(){
        }
    })
    
    $.ajax({
        type:"post",
        url:"Login/Logout",
        success:function(){
            alert("See you next time!");
            window.location.href="/";
        }
    })
}

function login(){
    $.ajax({
        type:"post",
        url:"Login",
        success:function(){
            window.location.href="/Login";
            $("#containThePartialforLogin").hide();
        }
    })
}

