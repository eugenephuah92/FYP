/**
 * Author: Elson Tan
 */
$(document).ready(function() {

    function resizeAllCharts(){
        if(jQuery().highcharts) {
            $('#chart').highcharts().reflow();
            $('#linechart').highcharts().reflow();
        }

    }
    function panelheightAdjust(obj){
        var docHeight = $(document).height();
        if(docHeight > obj.height()){
            obj.height(docHeight - 50);
        }
    }

    function closeAllSubMenus() {

        $(".nav-vertical > li").each(function () {
            //remove all hidden too
            $(this).removeClass('hidden');

            var me = $(this).find('a.nav-parent');
            if(me.hasClass('child-opened')) {
                me.parent().find('> .children').slideUp(200, function(){
                    me.find('i.fa-sort-up').removeClass('fa-sort-up mts').addClass('fa-sort-down');
                    me.removeClass('child-opened nav-active');
                });
            }
        });
    }

    function filter(element,e) {
        var value = $(element).val().toLowerCase();
        if($.trim(value).length > 0){
            $(".nav-vertical > li").each(function () {
                $this = $(this);
                lower = $this.text().toLowerCase();
                if(!$this.hasClass('search')){
                    if (lower.indexOf(value) > -1) {
                        $this.removeClass('hidden');

                    } else {
                        $this.addClass('hidden');
                    }
                }
            });
            submenuopen();

        } else {
            //empty!
            //close all submenus
            closeAllSubMenus();
        }
    }

    function submenuopen(){
        var inChild = false;
        var $submenu;
        $(".nav-vertical > li").each(function () {
            $this = $(this);
            if(!$this.hasClass('hidden')){
                //is not hidden
                if($this.find('a').hasClass('nav-parent')){
                    $submenu = $this.find('a');
                    inChild = true;
                }
            }
        });


        if(inChild){
            $('.left-panel').css({height: ''});

            $submenu.parent().find("> .children").slideDown(200, function(){
                panelheightAdjust($('.left-panel'));
            });
            $submenu.find('i.fa-sort-down').removeClass('fa-sort-down').addClass('fa-sort-up mts');
            $submenu.addClass('child-opened nav-active');
            panelheightAdjust($('.left-panel'));
        }
    }


    function resizeFixedHeader(){
        if($('.table-fixed-header .header').length > 0){
            var headerwidth;
            if($('.panel-close').hasClass('closed')){
                var headerwidth = "96.4%";
            } else {
                headerwidth = $('.table-fixed-header').width();
            }

            $('.header-copy').css({'width': headerwidth});
        }
    }

    //readjust left panel height if right panel content height is larger.
    if(($('.right-panel').height() + 40) > $('.left-panel').height()){
        $('.left-panel').css({height: ''});
        panelheightAdjust($('.left-panel'));
    }

    /**
     * jQuery submenu animation
     */

    $('li a.nav-parent').click( function(e){

        var me = $(this);
            e.preventDefault();
            if(me.hasClass('child-opened')){
                //child already opened > close
                $('.left-panel').css({height: ''});

                me.parent().find("> .children").slideUp(200, function(){
                    panelheightAdjust($('.left-panel'));
                });

                me.parent().find('> a i.fa-sort-up').removeClass('fa-sort-up mts').addClass('fa-sort-down');

                me.removeClass('child-opened nav-active');

                //level 1 parent clicked
                if(me.parent().parent().hasClass('nav-pills')){
                    closeAllSubMenus();
                }
            } else {
                //child not opened > open

                $('.left-panel').css({height: ''});

                me.parent().find("> .children").slideDown(200, function(){
                    panelheightAdjust($('.left-panel'));
                });
                me.find('i.fa-sort-down').removeClass('fa-sort-down').addClass('fa-sort-up mts');

                me.addClass('child-opened nav-active');
            }

        e.stopPropagation();

            $('.left-panel').css({height: ''});
            panelheightAdjust($('.left-panel'));

    });


    /**
     * Left Panel and Right Panel animations
     */
    $('.panel-close').click(function(e){
        var me = $(this);
        e.preventDefault();
        if(me.hasClass('closed')){
            $('.right-panel').animate({ width : '-=20%'}, 300);
            $('.panel-close .fa').addClass('fa-arrow-left').removeClass('fa-arrow-right');

            $('.left-panel, .panel-close').animate({ left : '+=20%'}, 300, function(){
                me.removeClass('closed');
                resizeFixedHeader();
                resizeAllCharts();
            });

        } else {
            $('.right-panel').animate({ width : '+=20%'}, 300);

            $('.panel-close .fa').removeClass('fa-arrow-left').addClass('fa-arrow-right');

            $('.left-panel, .panel-close').animate({ left : '-=20%'}, 100, function(){
                me.addClass('closed');
                resizeFixedHeader();
                resizeAllCharts();
            });
        }
        $('.left-panel').css({height: ''}); //to prevent left panel height from stacking up
        panelheightAdjust($('.left-panel'));

    });

    /**
     * Menu Search Function
     */
    $('#menuSearch').on('change keyup paste', function(e){
        var me = $(this);
        filter(me,e);
    });


    $(window).resize(function() {
        if($('.nav-vertical').is(':hidden')) {
            $('.right-panel').animate({ width : '100%'}, 100);
        } else {
            $('.left-panel-inner').removeAttr('style');
            $('.right-panel').animate({ width : '80%'}, 100);

            $('.left-panel').css({
                'position': 'absolute',
                'width': '20%',
                'z-index': '9999',
                'overflow-y': ''
            }).addClass('hidden-xs hidden-sm');
            $('#menu-toggle').removeClass('opened').addClass('closed');
        }


        return false;
    });

    /*
    Menu toggle in small screen devices xs and sm
     */
    $('#menu-toggle').click(function(){
        var me = $(this);
        if($('.left-panel').hasClass('closed')){
            $('.left-panel').animate({ left : '+=25%'}, 300, function(){
                me.removeClass('closed');
            });
        }
        if(me.hasClass('closed')){
            //open it

            $('.left-panel').css({
                'position': 'absolute',
                'width': '80%',
                'z-index': '9999',
                'overflow-y': 'auto'
            }).removeClass('hidden-xs hidden-sm');
            me.removeClass('closed').addClass('opened');
        } else {

            $('.left-panel').css({
                'position': 'absolute',
                'width': '20%',
                'z-index': '9999',
                'overflow-y': ''
            }).addClass('hidden-xs hidden-sm');
            me.removeClass('opened').addClass('closed');
        }

        $('.left-panel').css({height: ''}); //to prevent left panel height from stacking up
        panelheightAdjust($('.left-panel'));

    });

    /*
    Drop Down
     */
    $('.dropdown-menu li a').click(function(){
        var me = $(this);
        var getT = $(this).text();
        if(getT != $('.dropdown-toggle').text()){
            me.text($('.dropdown-toggle').text());
            $('.dropdown-toggle').html('<i class="fa fa-fa fa-globe"></i>&nbsp;'+ getT + '<b class="caret"></b>');
        }
    });

    /**
     * Menu will become fixed when scroll down on mobile view
     */

    $(document).scroll(function () {
        var ele;
        var y = $(this).scrollTop();

        if($('#menu-toggle').is(':visible')){
            ele = parseInt($('.useraccount').height()) + 50 ;
            if(y >= ele){
                //scroll beyond the element
                $('.left-panel-inner').attr('style','position:fixed;top:0px;width:80%;');
            }else{
                $('.left-panel-inner').removeAttr('style');
            }
        }

    });

    /**
     * Notification Simulator (remove this when UI is ready for production)
     */
    $('#sim-n').click(function(e){
        e.preventDefault();
        var text = {
            "body" : $.trim($('#newn').val()),
            "link": $.trim($('#newn-a').val())
        }
        if(text.body.length > 0 && text.link.length > 0){
            notification.new(text.link, text.body, '1sec', e);
        } else {
            //do nothing since user has not entered anything
        }

        e.stopPropagation(); //stop event from bubbling if spam click

    });

    $('#sim-clear').click(function(e){
        e.preventDefault();
       notification.hideAll();
    });



});