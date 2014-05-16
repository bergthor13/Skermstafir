$(document).ready(function () {
    var stillOpen = false;

    // Makes a click event on all trashcans. (View = Account/Manage)
    $(".deletebtn").click(function () {
        if (stillOpen == false) {
            $(this).parent().children().show();
            $(this).hide();
            stillOpen = true;
        }
    });

    // Makes a click event on all cancel delete buttons. (View = Account/Manage)
    $(".deletecancel").click(function () {
        $(this).parent().children().hide();
        $(this).parent().find(".deletebtn").show();
        stillOpen = false;
    });

    //Makes sure that comments are not empty. (View = Subtitle/ShowSubtitle)
    $("#btnSave1").click(function () {
        if ($("#CommentText1").val() === "") {
            $("#CommentText1").addClass("commentError").fadeIn();
            $("#titleError2").fadeIn();
            event.preventDefault();
        }
        else {
            $("#titleError").hide();
            $("#CommentText1").removeClass("commentError");
        }
    });

    // Makes sure that requests and subtitles have titles.
    $("#postNew").submit(function(event) {
        if ($("#titleBox").val() === "") {
            $("#titleBox").addClass("commentError").fadeIn();
            $("#titleError").fadeIn();
            event.preventDefault();
        }
        else {
            $("#titleError").hide();
            $("#titleBox").removeClass("commentError");
        }
    });
});

