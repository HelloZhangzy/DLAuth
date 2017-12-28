(function ($) {


    menuItemClick = function ()
    {
        $('.LoadPage').html();
    }

    var init = function () {
        $('.menuItem').on('click', menuItemClick);
    };

    $(function () {
        init();
    });
})(jQuery); 
