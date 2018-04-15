// Write your JavaScript code.

$(function () {
    "use strict";




    /* ==========================================================================
   Preload
   ========================================================================== */

    $(window).load(function () {

        $("#status").fadeOut();

        $("#preloader").delay(1000).fadeOut("slow");
    });


    /* ==========================================================================
   Background Slideshow images
   ========================================================================== */

    $(".main").backstretch([
        "https://www.sousvidecenter.com/images/articles/sous-vide-meat-color.jpg",
        "https://i.ytimg.com/vi/NaMtktnlb4A/maxresdefault.jpg",
        "https://www.simplyrecipes.com/wp-content/uploads/2017/04/2017-045-17-Sous-Vide-French-Dip-Sandwiches-37.jpg",
        //"images/banner1.svg",
        //"images/banner2.svg"

    ], {
            fade: 750,
            duration: 4000
        });


    /* ==========================================================================
   On Scroll animation
   ========================================================================== */

    if ($(window).width() > 992) {
        new WOW().init();
    };


    /* ==========================================================================
   Fade On Scroll
   ========================================================================== */
    
    if ($(window).width() > 992) {

        $(window).on('scroll', function () {
            $('.main').css('opacity', function () {
                return 1 - ($(window).scrollTop() / $(this).outerHeight());
            });
        });
    };

    /* ==========================================================================
   countdown
   ========================================================================== */

    $('.countdown').downCount({
        date: '12/15/2019 12:00:00' // m/d/y
    });


    /* ==========================================================================
     sub form
     ========================================================================== */

    var $form = $('#mc-form');

    $('#mc-subscribe').on('click', function (event) {
        if (event)
            event.preventDefault();
        register($form);
    });

    function register($form) {
        $.ajax({
            type: $form.attr('method'),
            url: $form.attr('action'),
            data: $form.serialize(),
            cache: false,
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            error: function (err) {
                $('#mc-notification').hide().html('<span class="alert">Could not connect to server. Please try again later.</span>').fadeIn("slow");

            },
            success: function (data) {

                if (data.result != "success") {
                    var message = data.msg.substring(4);
                    $('#mc-notification').hide().html('<span class="alert"><i class="fa fa-exclamation-triangle"></i>' + message + '</span>').fadeIn("slow");

                } else {
                    var message = data.msg.substring(4);
                    $('#mc-notification').hide().html('<span class="success"><i class="fa fa-envelope"></i>' + 'Awesome! We sent you a confirmation email.' + '</span>').fadeIn("slow");

                }
            }
        });
    }


    /* ==========================================================================
     Textrotator
     ========================================================================== */



    $(".rotate").textrotator({
        animation: "dissolve",
        separator: ",",
        speed: 2500
    });

    /* ==========================================================================
       Contact Form
       ========================================================================== */


    $('#contact-form').validate({
        rules: {
            name: {
                required: true,
                minlength: 2
            },
            email: {
                required: true,
                email: true
            },

            message: {
                required: true,
                minlength: 10
            }
        },
        messages: {
            name: "<i class='fa fa-exclamation-triangle'></i>Please enter your name.",
            email: {
                required: "<i class='fa fa-exclamation-triangle'></i>Please Enter your email address.",
                email: "<i class='fa fa-exclamation-triangle'></i>Please enter a valid email address."
            },
            message: "<i class='fa fa-exclamation-triangle'></i>Please enter your message."
        },
        submitHandler: function (form) {
            $(form).ajaxSubmit({
                type: "POST",
                data: $(form).serialize(),
                url: "php/contact.php",
                success: function () {
                    $('#contact-form :input').attr('disabled', 'disabled');
                    $('#contact-form').fadeTo("slow", 0.15, function () {
                        $(this).find(':input').attr('disabled', 'disabled');
                        $(this).find('label').css('cursor', 'default');
                        $('.success-cf').fadeIn();
                    });
                },
                error: function () {
                    $('#contact-form').fadeTo("slow", 0.15, function () {
                        $('.error-cf').fadeIn();
                    });
                }
            });
        }
    });

    /* ==========================================================================
   ScrollTop Button
   ========================================================================== */


    $(window).scroll(function () {
        if ($(this).scrollTop() > 200) {
            $('.scroll-top a').fadeIn(200);
        } else {
            $('.scroll-top a').fadeOut(200);
        }
    });


    $('.scroll-top a').click(function (event) {
        event.preventDefault();

        $('html, body').animate({
            scrollTop: 0
        }, 1000);
    });



});
