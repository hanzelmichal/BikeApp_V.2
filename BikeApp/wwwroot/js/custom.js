$(function() {

    $('#login-form-link').click(function(e) {
		$("#login-form-link").delay(100).fadeIn(100);
 		$("#register-form-link").fadeOut(100);
		$('#register-form-link').removeClass('active');
		$(this).addClass('active');
		e.preventDefault();
	});
	$('#register-form-link').click(function(e) {
		$("#register-form-link").delay(100).fadeIn(100);
 		$("#login-form-link").fadeOut(100);
		$('#login-form-link').removeClass('active');
		$(this).addClass('active');
		e.preventDefault();
	});

});
