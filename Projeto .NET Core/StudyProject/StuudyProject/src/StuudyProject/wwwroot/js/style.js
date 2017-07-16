(function () {
    var ele = $("#username");
    ele.text("Fulano de tal da silva");

    //var main = $("#main");

    //$("#main").mouseover(function () {
    //    $(this).css({ 'background-color': '#888' });
    //});

    //$("#main").mouseout(function () {
    //    if (!$(this).hasClass('clicked'))
    //        $(this).css({ 'background-color': '#eee' });
    //});

    //var menuItems = $("ul.menu li a");
    //menuItems.on("click", function () {
    //    var me = $(this);
    //    alert(me.text());
    //})

    var $sidebarAndWrapper = $("#sidebar,#wrapper");
    var $icon = $("#sidebarToggle i.fa");

    $("#sidebarToggle").click(function () {

        $sidebarAndWrapper.toggleClass("hide-sidebar");
        if ($sidebarAndWrapper.hasClass("hide-sidebar")) {
            $icon.removeClass("fa-angle-left");
            $icon.addClass("fa-angle-right");
        } else {
            $icon.addClass("fa-angle-left");
            $icon.removeClass("fa-angle-right");
        }

    })

})();
