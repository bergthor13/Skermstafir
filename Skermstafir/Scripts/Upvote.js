function PostSubtitleUpvote(id) {
	// The object to send to server.
	var upvote = { "subid": id }
	var selector = "#subVoteCount-" + id;

	$.post("/Subtitle/UpvoteSubtitle", upvote, function success(response) {
		if (response.Exists === 0) {
			// Upvote
			var voteValue = $(selector).text();
			voteValue++;
			$(selector).text(voteValue);
		} else if (response.Exists === 1) {
			// Downvote
			var voteValue = $(selector).text();
			voteValue--;
			$(selector).text(voteValue);
		} else if (response.Exists === 2) {
			// Notandi á þýðinguna
			$(selector).notify("Þú getur ekki upvote-að þína þýðingu", { className: "info", elementPosition: 'right' });
		} else if (response.Exists === 3) {
			// Notandi ekki innskráður
			$(selector).notify("Þú verður að vera innskráð/ur", { className: "info", elementPosition: 'right' });
		}
	}).fail(function fail(bla1, bla2) {
		$(selector).notify("Villa kom upp. Afsakið." + bla2, { className: "error", elementPosition: 'right' });
	});

}

function PostRequestUpvote(id) {
	// The object to send to server.
	var upvote = { "reqid": id }
	var selector = "#reqVoteCount-" + id;

	$.post("/Request/UpvoteRequest", upvote, function success(response) {
		if (response.Exists === 0) {
			// Upvote
			var voteValue = $(selector).text();
			voteValue++;
			$(selector).text(voteValue);
		} else if (response.Exists === 1) {
			// Downvote
			var voteValue = $(selector).text();
			voteValue--;
			$(selector).text(voteValue);
		} else if (response.Exists === 2) {
			// Notandi á þýðinguna
			$(selector).notify("Þú getur ekki upvote-að þína beiðni", { className: "info", elementPosition: 'right' });
		} else if (response.Exists === 3) {
			$(selector).notify("Þú verður að vera innskráð/ur", { className: "info", elementPosition: 'right' });
		}
	}).fail(function fail(bla1, bla2) {
		$(selector).notify("Villa kom upp. Afsakið." + bla2, { className: "error", elementPosition: 'right' });
	});

}