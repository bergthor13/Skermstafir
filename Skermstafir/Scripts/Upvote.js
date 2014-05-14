$(document).ready(function myfunction() {
	//getUpvotes(id);
})

function PostSubtitleUpvote(id) {
	// The object to send to server.
	var upvote = { "subid": id }
	
	var selector = "#voteCount-" + id;
	
	$.post("/Subtitle/UpvoteSubtitle", upvote, function success(response) {
		if (response.Exists === 1) {
			// Downvote
			var voteValue = $(selector).text();
			voteValue--;
			$(selector).text(voteValue)
		} else if (response.Exists === 3) {
			$(selector).notify("Þú verður að vera innskráð/ur", { className: "info", elementPosition: 'left' });
		} else if (response.Exists === 2) {
			// Notandi á þýðinguna
			$(selector).notify("Þú getur ekki upvote-að þína þýðingu", { className: "info", elementPosition: 'left' });
		} else if (response.Exists === 0) {
			// Upvote
			var voteValue = $(selector).text();
			voteValue++;
			$(selector).text(voteValue)
		}
	}).always(function () {
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
	});

}