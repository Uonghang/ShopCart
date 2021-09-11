$(document).ready(function() {
    $('.carousel').slick({
        slidesToShow: 3,
        slidesToScroll: 2,
        prevArrow: false,
        nextArrow: false,
        dots: true,
        responsive: [{

            breakpoint: 1024,
            settings: {
                slidesToShow: 3,
                infinite: true
            }

        }, {

            breakpoint: 800,
            settings: {
                slidesToShow: 2,
                dots: true
            }

        }, {
            breakpoint: 480,
            settings: {
                slidesToShow: 1,
                dots: true
            }
        }]

    });
    $('.icon-menu').click(function() {
        $('.menu-doc').addClass('active');
        $('.cover').addClass('active');

    })
    $('.cover').click(function() {
        $('.cover').removeClass('active');
        $('.menu-doc').removeClass('active');
    })

});
