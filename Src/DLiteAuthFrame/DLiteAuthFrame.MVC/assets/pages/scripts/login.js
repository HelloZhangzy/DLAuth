var Login = function () {

    var handleLogin = function () {
        $('.login-form').validate({
            errorElement: 'span', //default input error message container
            errorClass: 'help-block', // default input error message class
            focusInvalid: false, // do not focus the last invalid input
            rules: {
                username: {
                    required: true
                },
                password: {
                    required: true
                }
            },
            messages: {
                username: {
                    required: "«Î ‰»Î’À∫≈."
                },
                password: {
                    required: "«Î ‰»Î√‹¬Î."
                }
            },

            invalidHandler: function (event, validator) { //display error alert on form submit   
              //  $('.alert-danger', $('.login-form')).html('«Î ‰»Î’À∫≈∫Õ√‹¬Î' + '<button class="close" data-close="alert"></button>');
                $('.alert-danger').text('«Î ‰»Î’À∫≈∫Õ√‹¬Î');
                $('.alert-danger', $('.login-form')).show(); 
            },

            highlight: function (element) { // hightlight error inputs
                $(element)
                    .closest('.form-group').addClass('has-error'); // set error class to the control group
            },
            success: function (label) {
                label.closest('.form-group').removeClass('has-error');
                label.remove();
            },

            errorPlacement: function (error, element) {
                error.insertAfter(element.closest('.input-icon'));
            },
            submitHandler: function (form) {
                $.ajax({
                    type: 'post',
                    dataType: 'json',
                    url: '/Account/Login',
                    data: { Name: $('#username').val(), PassWord: $('#password').val() },
                    success: function (res) {
                        if (res.state == 'success') {
                            location.href = res.Url;
                        }
                        else {
                            
                            //$('.alert-danger', $('.login-form')).text(res.message);
                            $('.alert-danger', $('.login-form')).show().html(res.message +'<button class="close" data-close="alert"></button>');                           
                        }

                    },
                    error: function (err) {
                    }

                });
            }
        });

        $('.login-form input').keypress(function (e) {
            if (e.which == 13) {
                if ($('.login-form').validate().form()) {
                    $('.login-form').submit();
                }
                return false;
            }
        });
    }

    var handleValidation = function () {
        var form = $('.login-form');

        form.validate({
            errorElement: 'span', //default input error message container
            errorClass: 'help-block help-block-error', // default input error message class
            focusInvalid: false, // do not focus the last invalid input
            ignore: "",  // validate all fields including form hidden input
            rules: {                
                username: {
                    maxlength: 50,
                    required: true
                },
                password: {
                    maxlength: 50,
                    required: true
                }
            },
            errorPlacement: function (error, element) { // render error placement for each input type
                var icon = $(element).parent('.input-icon').children('i');
                icon.removeClass('fa-check').addClass("fa-warning");
                icon.attr("data-original-title", error.text()).tooltip({ 'container': 'body' });
            },

            highlight: function (element) { // hightlight error inputs
                $(element).closest('.form-group').removeClass("has-success").addClass('has-error'); // set error class to the control group
            },
            unhighlight: function (element) { // revert the change done by hightlight

            },
            success: function (label, element) {
                var icon = $(element).parent('.input-icon').children('i');
                $(element).closest('.form-group').removeClass('has-error').addClass('has-success'); // set success class to the control group
                icon.removeClass("fa-warning").addClass("fa-check");
            },
            submitHandler: function (form) {               
                CheckLogin();
            }
        });

        $('.login-form input').keypress(function (e) {
            if (e.which == 13) {
                if ($('.login-form').validate().form()) {
                    CheckLogin();
                    //$('.login-form').submit();
                }
                return false;
            }
        });
    }
   
    

    return {       
        init: function () {   
            //Ladda.bind('input[type=submit]');           
            handleValidation();
        }
    };

}();

CheckLogin = function () {
    $('.btn-success').addClass('disabled');
    $.ajax({
        type: 'post',
        dataType: 'json',
        url: '/Account/Login',
        data: { Name: $('#username').val(), PassWord: $('#password').val() },
        success: function (res) {
            if (res.state == 'success') {
                location.href = res.Url;
            }
            else {
                $('.alert-danger', $('.login-form')).show().html(res.message + '<button class="close" data-close="alert"></button>');
                $('.btn-success').removeClass('disabled');
            }
        },
        error: function (err) {
            $('.btn-success').removeClass('disabled');
        }
    });   
   
}

jQuery(document).ready(function () {

    //$btn = $('.login-form');
    //btn.bind("submit", CheckLogin);
    //$showmore.trigger('submit');
    Login.init();
});