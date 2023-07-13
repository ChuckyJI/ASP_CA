function addnumber(i) {
    var counterElement = document.getElementsByClassName("cartQtycount")[i];
    var currentValue = parseInt(counterElement.innerText);
    counterElement.innerText = currentValue + 1;
}

function minusnumber(i) {
    var counterElement = document.getElementsByClassName("cartQtycount")[i];
    var currentValue = parseInt(counterElement.innerText);
    if (currentValue > 0){
        counterElement.innerText = currentValue - 1;
    }
    if (currentValue === 0){
        counterElement.innerText = currentValue;
    }
}

window.setInterval(function() {
    var Singalpriceinput = document.getElementsByClassName("SingalPrice");
    var countinput = document.getElementsByClassName("cartQtycount");
    var totalSpan = document.getElementsByClassName("totalPrice");
    for (let i = 0;i<Singalpriceinput.length;i++){
        let singalpi = parseInt(Singalpriceinput[i].innerHTML);
        let countip = parseInt(countinput[i].innerHTML);
        let totals = totalSpan[i];
        totals.innerText = singalpi * countip;
    }
}, 50);

window.setInterval(function (){
    var sum = document.getElementById("generalTotalPrice");
    var totalSpan = document.getElementsByClassName("totalPrice");
    var a = 0;
    for (var i =0;i <totalSpan.length ;i++){
        let generalTotalPriceOrigin = parseInt(totalSpan[i].innerHTML);
        a = a + generalTotalPriceOrigin;
    }
    sum.innerHTML = a;
},50)


function cartToOrder(){
    var carttoorderName = document.getElementsByClassName("carttoorderName");
    var cartQtycount = document.getElementsByClassName("cartQtycount");
    var carttoorderPrice=document.getElementsByClassName("carttoorderPrice");
    
    // get the current time
    let currentDate = new Date();
    let currentDataString = currentDate.toString();
    let hours = currentDate.getHours();
    let minutes = currentDate.getMinutes();
    let seconds = currentDate.getSeconds();
    let year = currentDate.getFullYear();
    let month = currentDate.getMonth()+1;
    let day=currentDate.getDate();
    let currentDay = year+"-"+month+"-"+day;
    let currentTime=hours+":"+minutes+":"+seconds;
    let fulltime = currentDay+" "+currentTime;
    
    var list = [];
    for(var i = 0; i<carttoorderName.length ;i++)
    {
        list.push(carttoorderName[i].innerHTML,cartQtycount[i].innerHTML,carttoorderPrice[i].innerHTML,fulltime);
    }
    
    $.ajax({
        type:"post",
        url:"Order/CartToOrder",
        data:{carttoorder:list},
        success:function(data){
            if (data.success === true){
                alert("Have a nice shopping experience!");
                window.location.href="Mypurchase";
            }
            else{
                alert("Please log in first!");
                window.location.href="/Login";
            }
        },
    });
}

function backToStore(){
    var carttoorderName = document.getElementsByClassName("carttoorderName");
    var cartQtycount = document.getElementsByClassName("cartQtycount");
    var list = [];
    for (let i = 0 ; i <carttoorderName.length;i++)
    {
        list.push(carttoorderName[i].innerHTML,cartQtycount[i].innerHTML);
    }
    $.ajax({
        type:"post",
        url:"Order/backToStore",
        data:{upadtedata:list},
        success:function(){
            window.location.href="/"
        },
    })
}

function clearTheCart(){
    var temp = [];
    $.ajax({
        type:"post",
        url:"Order/emptyCart",
        data:{emptyCart:temp},
        success:function(){
            alert("Cart has been empty!");
            window.location.href="Cart";
        }
    })
}