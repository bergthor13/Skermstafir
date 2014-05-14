$(Document).ready(function () {
})

function comment() {
    alert("trying");
    var comment = {
        IdComment: 0,
        Username: "Dabs",
        Content: "Bla",
        DateCreated: Date.now()
    };
    $.post("Subtitle/Comment", comment, function (data) {
        alert("tókst")
    });
}