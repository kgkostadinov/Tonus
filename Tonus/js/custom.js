
$(document).scroll(function () {
    var scrollPos = $(this).scrollTop();
    var nav = $('#nav');
    var logo = $('#bigLogo');
    var container = $('#logoContainer');

    if (scrollPos > 0) {
        if (logo.attr('src')== '/images/TonusLogoSmall.png') {
            return;
        }

        nav.css({ height: '92px' });
        logo.fadeOut(20,function () {
            $(this).attr('src', '/images/TonusLogoSmall.png').bind('onreadystatechange load', function () {
                if (this.complete) {
                    nav.css({ 'line-height': '6em' });
                    container.css({'padding-top': 0});
                    $(this).css({ width: '86px', 'padding-top': 0 });
                    $(this).fadeIn(300);
                }
            });
        });
    }
    else {
        if (logo.attr('src') === '/images/TonusLogo.png') {
            return;
        }

        nav.css({ height: '235px' });
        logo.fadeOut(20, function () {
            $(this).attr('src', '/images/TonusLogo.png').bind('onreadystatechange load', function () {
                if (this.complete) {
                    nav.css({ 'line-height': '15em' });
                    container.css({ 'padding-top': '2em' });
                    $(this).css({ width: '500px', 'padding-top': '0'});
                    $(this).fadeIn(300);
                }
            });
        });


    }
})