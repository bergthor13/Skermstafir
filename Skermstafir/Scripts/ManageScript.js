var stillOpen = false;

function DeleteSub(theElement, theID) {
    if (stillOpen == false) {
        var realID = theID.substring(4);
        $(theElement).replaceWith("<button type=\"button\" id=\"" + theID + "\" class=\"btn btn-default deleteok\" onclick=\"location.href=\'/Subtitle/DeleteSubtitle/" + realID + "\'\"><span class=\"glyphicon glyphicon-ok\"></span></button> <button type=\"button\" class=\"btn btn-default deletecancel\" onclick=\"DeleteSubCancel();\"><span class=\"glyphicon glyphicon-remove\"></span></button>");
        stillOpen = true;
    }
};

function DeleteReq(theElement, theID) {
    if (stillOpen == false) {
        var realID = theID.substring(4);
        $(theElement).replaceWith("<button type=\"button\" id=\"" + theID + "\" class=\"btn btn-default deleteok\" onclick=\"location.href=\'/Request/DeleteRequest/" + realID + "\'\"><span class=\"glyphicon glyphicon-ok\"></span></button> <button type=\"button\" class=\"btn btn-default deletecancel\" onclick=\"DeleteReqCancel();\"><span class=\"glyphicon glyphicon-remove\"></span></button>");
        stillOpen = true;
    }
};

function DeleteSubCancel() {
    var ID = $(".deleteok").attr('id');
    $(".deleteok").remove();
    $(".deletecancel").replaceWith("<button type=\"button\" id=\"" + ID + "\" class=\"btn btn-default deletebtn\" onclick=\"DeleteSub($(this), $(this).attr('id'));\"><span class=\"glyphicon glyphicon-trash\"></span></button>");
    stillOpen = false;
};

function DeleteReqCancel() {
    var ID = $(".deleteok").attr('id');
    $(".deleteok").remove();
    $(".deletecancel").replaceWith("<button type=\"button\" id=\"" + ID + "\" class=\"btn btn-default deletebtn\" onclick=\"DeleteReq($(this), $(this).attr('id'));\"><span class=\"glyphicon glyphicon-trash\"></span></button>");
    stillOpen = false;
};