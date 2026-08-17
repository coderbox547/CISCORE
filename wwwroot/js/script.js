
$(function () {
	$(window).scrollTop(0);
});


$(document).ready(function () {

	scrollToServiceSection();
	scrollToProcessSection();
	scrollToContactSection();
	scrollToTestimonialsSection();
	FooterSection();
});


$(function () {
	var url = new URL(window.location.href);
	var param = url.searchParams.get("tag");
	if (param == "service") {
		serviceSection();
	}
	else if (param == "process") {
		processSection();
	}
	else if (param == "contact") {
		contactSection();
	}
	else if (param == "testimonials") {
		testimonialsSection();
	}

});



function scrollToProcessSection() {
	$("#ProcessColumn").click(function () {
		processSection();
	});
}

function scrollToServiceSection() {
	$("#ServiceColumn").click(function () {
		serviceSection();
	});
}

function scrollToContactSection() {
	$("#ContactColumn").click(function () {
		contactSection();
	});
}

function scrollToTestimonialsSection() {
	$("#Reviews").click(function (e) {
		testimonialsSection();
	});
}


//for scroll to specific section 	

function processSection() {
	$('html,body').animate({
		scrollTop: $("#ProcessSection").position().top - 120
	}, 'slow');
}

function serviceSection() {
	$('html,body').animate({
		scrollTop: $("#ServicesSection").position().top - 150
	}, 'slow');
}

function contactSection() {
	$('html,body').animate({
		scrollTop: $(".1topc-b7").position().top
	}, 'slow');
}

function testimonialsSection() {
	$('html,body').animate({
		scrollTop: $("#TestimonialsSection").position().top
	}, 'slow');
}




//js for back to top button 

$(document).ready(function () {

	$(window).scroll(function () {
		if ($(this).scrollTop() > 100) {
			$('.scrollup').fadeIn();
		} else {
			$('.scrollup').fadeOut();
		}
	});

	$('.scrollup').click(function () {
		$("html, body").animate({
			scrollTop: 0
		}, 600);
		return false;
	});

});





