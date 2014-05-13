$(document).ready(function myfunction() {
	getUpvotes(id);
})
function PostUpvoteSingle(id) {
	// Check if the username is empty.
	if ($("#UserName").val() === "") {
		$("#UsernameError").text("Username can not be empty!");
		return;
	} else {
		$("#UsernameError").text("");
	}
	// The object to send to server.
	var like = { "CommentID": id, "Username": $("#UserName").val() }

	// Send the like to server.
	// Alerts if the username exists for this comment.
	// Server checks for that.
	// Then we always refresh the comments.
	$.post("/Home/LikeComment", like, function success(response) {
		if (response.Exists === 1) {
			alert("You have liked this comment.")
		}
	}).always(function () {
		refreshComments();
	});
	
}

function GetUpvoteSingle(id) {
	// Check if the username is empty.
	if ($("#UserName").val() === "") {
		$("#UsernameError").text("Username can not be empty!");
		return;
	} else {
		$("#UsernameError").text("");
	}
	// The object to send to server.
	var like = { "CommentID": id, "Username": $("#UserName").val() }

	// Send the like to server.
	// Alerts if the username exists for this comment.
	// Server checks for that.
	// Then we always refresh the comments.
	$.post("/Home/LikeComment", like, function success(response) {
		if (response.Exists === 1) {
			alert("You have liked this comment.")
		}
	}).always(function () {
		refreshComments();
	});

}