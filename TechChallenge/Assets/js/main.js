$(".btn-submit").click(function () {
    var numberAndName = $(".numberandname").val();
    var name = numberAndName.replace(/[^a-zA-Z]/g, '');
    var doublenumber = Number(numberAndName.replace(/[^0-9\.]+/g, ""));
    var apiUrl = "http://localhost:15399/api/WordsConverstion/" + doublenumber
    $.ajax({
        cache: false,
        url: apiUrl,
        success: function (result) {
            $(".person-name").html(name);
            $(".result").html(result);
        }
    });
});