$(document).ready(function () {

    /*var ImageMasiv = [
        "/images/user/twitter.png",
        "/images/user/applemusicicon.png",
        "/images/user/cash.png",
        "/images/user/customlink.png",
        "/images/user/facebookicon (1).png",
        "/images/user/googlemaps.png",
        "/images/user/imessage.png",
        "/images/user/insta.png",
        "/images/user/linkedin.png",
        "/images/user/mailicon.png",
        "/images/user/paypal.png",
        "/images/user/safari.png",
        "/images/user/soundcloudnew.png",
        "/images/user/spotify.png",
        "/images/user/tiktok.png",
        "/images/user/twitchicon_new.png",
        "/images/user/twitter.png",
        "/images/user/venmo.png",
        "/images/user/whatsapp.png",
        "/images/user/snapchat.png",
        "/images/user/youtube.png"

    ]*/



  

 
    $(".imagetest").click(function () {
        $("#slider").slideUp()
        $("#insta15").slideDown()
    });
    $('.trigger').click(function () {

        $('#slider').slideDown();
          $("#block").slideUp()
          $("#image").hide()
    });
    $("#krest").click(function () {
        $("#slider").slideUp()
    });

   

    $(".imagetest").click(

        function () {
            let a = $(this).attr("src");
            $("#link_icon").attr("src", a);
        }
    )
    var t = true;



    $("#jjj").click(function () {

        if (t) {
            $("#jjj").css("background-color", "#3bd950")
            $("#jjj").text("Seve")
            $(".image").show();
            $("#block").slideDown()
            t = false;
            
        }
        else {
            $("#jjj").css("background-color", "#007bff")
            $("#jjj").text("Edit")
            $(".image").hide();
            $("#block").slideUp()
            t = true;
          
        }


        //$('#block').toggle()

    });

    var t1 = true;
    $("#btn").click(function () {
        if (t1) {
            $("#btn").css("background-color", "#3bd950")
            $("#btn").text("Direct on")
            t1 = false
        }
        else {
            $("#btn").css("background-color", "#007bff")
            $("#btn").text("Direct off")
            t1 = true
        }
        $(".popl").toggle();
    })
    $("#addlink").click(function () {
        $("#slider").slideDown()

      
    })


    $("#send").click(function () {

        var imagelink = $("#link_icon").attr("src");
        var username = $("#usr").val();
        var id = $(".User_Id").val();
      
        $.ajax({
            method: 'get',
            url: '../../api/ajax/api',
            data: { 'imagelink': imagelink, 'username': username ,'id':id},
            success: function (data) {
                var s = "";
                var x = $(".tuzik").html();
                for (i = 0; i < data.length; i++) {
                    s += " <div class='col - 6'> <img class='img - fluid mt - 3 trigger' src =" + data[i] + ">  " 
                    //alert(data[i]["imagelink"]);
                }
              
                x += s;
                $(".tuzik").html(x);

                $("#hdd").hide();

                location.reload();
                
            }
        })
    
    
      
   

});

 /* $(".xpac_img").click(function () {
        var imagelink = $("#link_icon").attr("src");

       $.ajax({
            method: 'get',
            url: '../../api/ajax/news',
           data: { 'imagelink': imagelink },
            success: function (data) {

                alert(data)
               *//* let a = $(".xpac_img").index(this)

                $(".xpac_div").eq(a).hide();
                location.reload();*//*

            }
        })
*/




    $(".xpac_img").click(function () {
        //let a = $(".xpac_img_inner").attr("src")
      //  alert(a)

        //$(".xpac_div").eq(a).hide();
       /* let a = $(".xpac_div").index(this);
        alert($(".xpac_div > xpac_img_inner").eq(a).attr("src"))*/

        let a = $(".xpac_img").index(this);
       
        let imagelink = $(".xpac_img_inner").eq(a).attr("src")

        $.ajax({
            method: 'get',
            url: '../../api/ajax/news',
            data: { 'imagelink': imagelink },
            success: function (data) {


             
                    $(".xpac_div").eq(a).hide();
          

            }
        })
        location.reload();

    })


});








