(function($){
    $.fn.scrollingTo = function( opts ) {
        var defaults = {
            animationTime : 1000,
            easing : '',
            callbackBeforeTransition : function(){},
            callbackAfterTransition : function(){}
        };

        var config = $.extend( {}, defaults, opts );

        $(this).click(function(e){
            var eventVal = e;
            e.preventDefault();

            var $section = $(document).find( $(this).data('section') );
            if ( $section.length < 1 ) {
                return false;
            };

            if ( $('html, body').is(':animated') ) {
                $('html, body').stop( true, true );
            };

            var scrollPos = $section.offset().top;

            if ( $(window).scrollTop() == scrollPos ) {
                return false;
            };

            config.callbackBeforeTransition(eventVal, $section);

            $('html, body').animate({
                'scrollTop' : (scrollPos+'px' )
            }, config.animationTime, config.easing, function(){
                config.callbackAfterTransition(eventVal, $section);
            });
        });
    };

    /* ========================================================================= */
    /*   Contact Form Validating
    /* ========================================================================= */

    //$('#contact-form').validate({
    //    rules: {
    //        name: {
    //            required: true, minlength: 4
    //        }
    //        , email: {
    //            required: true, email: true
    //        }
    //        , subject: {
    //            required: false,
    //        }
    //        , message: {
    //            required: true,
    //        }
    //        ,
    //    }
    //    , messages: {
    //        user_name: {
    //            required: "Come on, you have a name don't you?", minlength: "Your name must consist of at least 2 characters"
    //        }
    //        , email: {
    //            required: "Please putffffff your email address",
    //        }
    //        , message: {
    //            required: "Put some messages here?", minlength: "Your name must consist of at least 2 characters"
    //        }
    //        ,
    //    }
    //    , submitHandler: function(form) {
    //        $(form).ajaxSubmit( {
    //            type:"POST", data: $(form).serialize(), url:"sendmail.php", success: function() {
    //                $('#contact-form #success').fadeIn();
    //            }
    //            , error: function() {
    //                $('#contact-form #error').fadeIn();
    //            }
    //        }
    //        );
    //    }
    //});


}(jQuery));



jQuery(document).ready(function(){
	"use strict";
	new WOW().init();


(function(){
 jQuery('.smooth-scroll').scrollingTo();
}());

});




$(document).ready(function(){

    $(window).scroll(function () {
        if ($(window).scrollTop() > 50) {
            $(".navbar-brand a").css("color","#fff");
            $("#top-bar").removeClass("animated-header");
        } else {
            $(".navbar-brand a").css("color","inherit");
            $("#top-bar").addClass("animated-header");
        }
    });

    $("#clients-logo").owlCarousel({
 
        itemsCustom : false,
        pagination : false,
        items : 5,
        autoplay: true,

    });

    $("#socios-logo").owlCarousel({

        itemsCustom: false,
        pagination: false,
        items: 5,
        autoplay: true,

    });

});



// fancybox
$(".fancybox").fancybox({
    padding: 0,

    openEffect : 'elastic',
    openSpeed  : 450,

    closeEffect : 'elastic',
    closeSpeed  : 350,

    closeClick : true,
    helpers : {
        title : { 
            type: 'inside' 
        },
        overlay : {
            css : {
                'background' : 'rgba(0,0,0,0.8)'
            }
        }
    }
});


function CorreoFromJob() {
    var respuesta = "";
    object = document.getElementById("R_EPer");
    valueForm = object.value;
 
    var patronTelefono = new RegExp("^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$");
    if ($(object).val() == "") {
        var respuesta = "";

    } else if (valueForm.search(patronTelefono)) {
        var respuesta = "";
        return;
    } else {
        var respuesta = "ok";
    }
    return respuesta;
}



function CorreoFromDW() {
    var respuesta = "";
    object = document.getElementById("DW_EPer");
    valueForm = object.value;

    var patronTelefono = new RegExp("^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$");
    if ($(object).val() == "") {
        var respuesta = "";

    } else if (valueForm.search(patronTelefono)) {
        var respuesta = "";
        return;
    } else {
        var respuesta = "ok";
    }
    return respuesta;
}

function CorreoFromDWInformacion() {
    var respuesta = "";
    object = document.getElementById("DW_EPer2");
    valueForm = object.value;

    var patronTelefono = new RegExp("^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$");
    if ($(object).val() == "") {
        var respuesta = "";

    } else if (valueForm.search(patronTelefono)) {
        var respuesta = "";
        return;
    } else {
        var respuesta = "ok";
    }
    return respuesta;
}


function CorreoFromSS() {
    var respuesta = false;
    object = document.getElementById("Com_Email");
    valueForm = object.value;

    var patronTelefono = new RegExp("^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$");
    if ($(object).val() == "") {
        var respuesta = false;

    } else if (valueForm.search(patronTelefono)) {
        var respuesta = false;
        return;
    } else {
        var respuesta = true;
    }
    return respuesta;
}





