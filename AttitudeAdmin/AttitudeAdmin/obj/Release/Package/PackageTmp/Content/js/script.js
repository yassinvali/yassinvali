$(document).ready(function() {
	// $('.p-ellipsis').ellipsis({
	// 	row: 2,
	// 	onlyFullWords: true
	// });

    $(".fancybox").fancybox({   
        'overlayColor'      : '#000',
        'overlayOpacity'    : 0.8,
    });

    //jQuery to collapse the navbar on scroll
    /*function collapseNavbar() {
        if ($(".navbar").offset().top > 150) {
            $(".navbar-fixed-top").removeClass("top-nav-collapse");
        } else {
            $(".navbar-fixed-top").addClass("top-nav-collapse");
        }
    }
    $(window).scroll(collapseNavbar);*/

});



$(function() {
	// Add/remove class with jquery based on vertical scroll
    //caches a jQuery object containing the header element
    var header = $("#back-top");
    $(window).scroll(function() {
    	var scroll = $(window).scrollTop();

    	if (scroll >= 100) {
    		header.addClass("active");
    	} else {
    		header.removeClass("active");
    	}
    });

    // jQuery for page scrolling feature - requires jQuery Easing plugin
    $('a.page-scroll').bind('click', function(event) {
    	var $anchor = $(this);
    	$('html, body').stop().animate({
    		scrollTop: $($anchor.attr('href')).offset().top
    	}, 1500, 'easeInOutExpo');
    	event.preventDefault();
    });
});

// Highlight the top nav as scrolling occurs
$('body').scrollspy({
    target: '.navbar'
})

// marquee
$(function () {
    $('.marquee').each(function () {
        var $this = $(this);
        var $marquee = $this.find('marquee');
        //var $scrollup = $this.find('.scrollup');
        //var $scrolldn = $this.find('.scrolldn');

        $marquee
            .bind('mouseenter', function () {
                this.stop();
            })
            .bind('mouseleave', function () {
                this.start();
            });

       /* $scrollup
            .bind('mouseenter', function () {
                $marquee.attr('direction', 'up');
            });

        $scrolldn
            .bind('mouseenter', function () {
                $marquee.attr('direction', 'down');
            });*/
    });
});

