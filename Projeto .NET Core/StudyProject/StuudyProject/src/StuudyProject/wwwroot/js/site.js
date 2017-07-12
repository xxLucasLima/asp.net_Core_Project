(function () {
    var ele = $("#username");
    ele.text("Fulano de tal");

    var main = $("#main");
    main.on("mouseenter", function () {
        main.style = "background-color: #888;";

    });
    main.on("mouseleave", function () {
        main.style = "";
    });

    var menuItems = $("ul.menu li a");
    menuItems.on("click", function () {
        var me = $(this);
        alert(me.text());
    })
})();
