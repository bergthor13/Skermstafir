var stillOpen = false;

function DeleteSub(theElement, theID) {
    if (stillOpen == false) {
        var realID = theID.substring(4);
        $(theElement).replaceWith("<button type=\"button\" id=\"" + theID + "\" class=\"btn btn-default deleteok\" onclick=\"location.href=\'/Subtitle/DeleteSubtitle/" + realID + "\'\"><span class=\"glyphicon glyphicon-ok\"></span></button> <button type=\"button\" class=\"btn btn-default deletecancel\" onclick=\"DeleteSubCancel();\"><span class=\"glyphicon glyphicon-remove\"></span></button>");
        stillOpen = true;
    }
};

function reorder() {
	var text = $("#ascending").attr("data-AscDesc");
	if (text === "cba") {
		$("#dateAdded").click(function fun() {
			$.ajax({
				url: "/Search/OrderSubByDateAsc"
			}).fail(function fun() {
				alert("fail")
			}).success(function fun() {
				alert("success")
			});
		});

	} else if (text === "abc") {
		$("#dateAdded").click(function fun() {
			$.ajax({
				url: "/Search/OrderSubByDateDesc"
			}).fail( function fun() {
				alert("fail")
			});
		});
	}
}