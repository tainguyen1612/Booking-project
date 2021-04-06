

$(document).ready(function () {
    'use strict';

    // Load the SDK asynchronously
    (function (d) {
        var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
        if (d.getElementById(id)) { return; }
        js = d.createElement('script'); js.id = id; js.async = true;
        js.src = "//connect.facebook.net/en_US/sdk.js";
        ref.parentNode.insertBefore(js, ref);

    }(document));

    window.fbAsyncInit = function () {
        FB.init({
            appId: '151392186760103', // App ID
            status: true, // check login status
            cookie: true, // enable cookies to allow the server to access the session
            xfbml: true,  // parse XFBML
            version: 'v10.0'
        });
    };

    function Login() {
        FB.login(function (response) {
            if (response.authResponse) {
                getFacebookUserInfo();
            } else {
                console.log('User cancelled login or did not fully authorize.');
            }
        }, {
                scope: 'email,user_photos, '
            });
    }

    function getFacebookUserInfo() {
        FB.api('/me?fields=email,name,id', function (response) {
            //var token = $('input[name="__RequestVerificationToken"]').val();
            var url =  'LoginFaceBook'+'?name=' + response.name + "&email=" + response.email + "&id=" + response.id;
            //alert(url);
            window.location.href = url;
        });
    }

    function Logout() {
        FB.logout(function () { document.location.reload(); });
    }


    $('.lbtSignInFacebook').click(function () {
        Login();
    })

    $('.lbtLogOutFacebook').click(function () {
        Logout();
        var token = $('input[name="__RequestVerificationToken"]').val();
        $.ajax({
            url: "/Home/LogOut",
            headers: { "__RequestVerificationToken": token },
            type: "POST",
            success: function (data) {
                if (data.success === "True") {
                    location.reload();
                }
            },
            error: function (data) {
                console.log(data);
            }
        })
    })
});