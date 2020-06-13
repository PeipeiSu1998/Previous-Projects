
var takeScreenShot = function() {
    html2canvas(document.getElementsByClassName("container"), {
        onrendered: function (canvas) {
            var tempcanvas=document.createElement('canvas');
            tempcanvas.width=769;
            tempcanvas.height=466;
            var context=tempcanvas.getContext('2d');
            context.drawImage(canvas,50,116,769,466,0,0,920,466);
            var link=document.createElement("a");
            link.href=tempcanvas.toDataURL('image/png');
            link.download = 'screenshot.png';
            link.click();
        }
    });
}

var formToCardCompanyName = function(){
    var companyname = $('#companyname').val();
    $('.companyname').text(companyname);
}

var formToCardName = function(){
    var name = $('.fname').val();
    $('.name').text(name);
}
var formToCardAddress = function(){
    var address = $('#officeaddress').val();
    $('.officeaddress').text(address);
}
var formToCardEmail = function(){
    var email = $('#email').val();
    $('.email').text(email);
}

var formToCardPhone = function(){
    var phonenumber = $('#phonenumber').val();
    $('.phonenumber').text(phonenumber);
}

