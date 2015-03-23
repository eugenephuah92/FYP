/**
 * Notification Widget for Jabil
 * Author : Elson Tan
 *
 */

var notification = {
    settings : {
        'n_count': 1,                    // DO NOT EDIT, used as counter for current amount of notifications on screen.
        'b_count': 0,                    // DO NOT EDIT, used as counter for badge count on globe icon
        'max_n' : 3,                     //maximum number of notifications on screen. if exceeds the last notification will hide itself and new one appended to top.
        'fadeoutspeed': 200,             //general fade out speed (ms)
        'fadeinspeed': 200,              //general fade in speed (ms)
        'fadeout_notificationhide': 600, //fade out speed for hidding notification if exceed max_n (ms)
        'closetxt': 'Close',             //close text shown beside every single notification
        'appendToPanel': true,           // Append to hidden panel list when new notification is created
        'hasTimeout': true,              //hasTimeout specifies whether each notifcation will timeout and hide itself(true) or needed to be close manually(false)
        'timeout': 10000                 //timeout for notification, when time limit reached, it will hide itself (ms)
    },

    new: function(link, text, time){

    console.log(notification.settings.n_count);
        if($('.new-notification').is(':hidden')){
            $('.new-notification').show();
        }

        //html content for the new li
        var new_n = '<a class="main" href="'+ link +'">'
            +'<span class="content">'+ text +'</span>'
            +'<span class="time">'+ time +'</span>'
            +'</a><!--/.main-->'
            +'<a href="#" class="notification-close"><span class="close-txt">'+ notification.settings.closetxt +'</span></a>';

        var newnotification = $(document.createElement("li")); //createElement then wrap jQuery around it
        newnotification.html(new_n).css("display", "none").addClass('clearfix'); //jQuery set innerHTML and CSS

        $('.new-notification').prepend(newnotification); //Prepend to list

        newnotification.fadeIn(notification.settings.fadeinspeed, function() { //Select this and only this li element
                setTimeout(function(){
                    notification.timeoutHide(newnotification)
                }, notification.settings.timeout);
        });

        //remove the last child if exceeded max_n (maximum notifiction on screen)
        if(notification.settings.n_count > notification.settings.max_n){
            $('.new-notification li:last-child').animate({ height: 'toggle', opacity: 'toggle' }, notification.settings.fadeout_notificationhide, function(){
                $('.new-notification li:last-child').hide().remove();

                if($('.new-notification li').length == 0){
                    $('.new-notification').hide();
                }
            });
        } else {
            notification.settings.n_count++;
        }

        //you can remove this if production mode
        if(notification.settings.appendToPanel){
            var listhtml = '<li class="highlight">'
                +'<a href="#1" class="main">'+ text +'<span class="time">'+ time +'</span>'
                +'</a>'
                +'<a href="#" class="close">'
                 +   '<i class="fa fa-times"></i>'
                +'</a>'
            +'</li>';
            $('#notification-center-panel ul').prepend(listhtml);
        }

        notification.badge(true);//increase badge count
    },

    //manual hide
    hide: function(obj){
        $me  = obj;
        $me.parent().fadeOut(notification.settings.fadeoutspeed,function(){
            $me.parent().remove();
            notification.settings.n_count--;
            if($('.new-notification li').length == 0){
                $('.new-notification').hide();
            }
        });
    },

    hideAll: function(){
      $('.new-notification li').remove();
      $('.new-notification').hide();
        notification.settings.n_count = 1; //reset to 1
    },

    //auto timeout hide
    timeoutHide: function(obj){
        if($(obj).length > 0){
            $(obj).animate({ height: 'toggle', opacity: 'toggle' }, notification.settings.fadeout_notificationhide, function(){
                $(obj).hide().remove();
                notification.settings.n_count--; //reduce as each notification dissapear
                if($('.new-notification li').length == 0){
                    $('.new-notification').hide();
                }
            });
        }
    },

    badge: function(action){

        if(action){
            //increase badge count
            notification.settings.b_count++;
            $('#notification-panel-btn .badge').html(notification.settings.b_count);

        } else {
            //clear all badge and se tto 0
            notification.settings.b_count = 0;
            $('#notification-panel-btn .badge').html(notification.settings.b_count);
        }

        //hide it if the badge count is below or equals to 0
        if(parseInt($('#notification-panel-btn .badge').html()) <= 0){
            $('#notification-panel-btn .badge').hide();
        } else {
            $('#notification-panel-btn .badge').show();
        }
    }
};

$('body').on('click', '.notification-close' ,function(e){
    e.preventDefault();
    notification.hide($(this));
});

$('#notification-panel-btn').click(function(e){
    e.preventDefault();
    e.stopPropagation();
    $me = $(this);
   if($me.hasClass('open')){
       //current open , close it

       $me.removeClass('open');
       $('#notification-center-panel').hide();
       $('#notification-center-panel .highlight').removeClass('highlight');
   } else {
       //currently closed, open it
       notification.hideAll();

       $me.addClass('open');
       $('#notification-center-panel').show();
       notification.badge(false); //reset to 0 since user seen all
   }


});