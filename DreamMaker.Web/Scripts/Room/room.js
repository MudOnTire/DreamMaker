$(".js-join-room").click(function () {
    var $this = $(this);
    var href = $this.data(href);
    $.post(href, function(data) {
        console.log(data);
    });
});