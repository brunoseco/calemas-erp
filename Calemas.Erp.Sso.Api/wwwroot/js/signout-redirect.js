window.addEventListener("load", function () {
    var a = document.querySelector("a.RedirectUri");
    if (a) {
        window.location = a.href;
    }
});
