alert("before");
$(document).ready(function () {
    alert("in between");
    function SubDelete() {
        if (confirm('Ertu viss um að þú viljir eyða þessum skjátexta?')) {
            alert("true");
        }
        else {
            return;
        }
    }
});
alert("after");