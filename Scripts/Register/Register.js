
$("#email").focusout(function () {
    alert("hello this is for a jquery example , ll use this to fire ajax to check if email already exists or not. Sql Procedure given ");

});

$("#eyeShow").click(function () {
   
    if ($("#eyeShow").is(':checked')) {
        $("#password").attr('type', 'text');
    } else {
        $("#password").attr('type', 'password');
    }
    });


$("#eyeShow2").click(function () {

    $("#cpassword").attr('type', $(this).is(':checked') ? 'text' : 'password');
});

