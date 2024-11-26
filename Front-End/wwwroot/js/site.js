// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener("DOMContentLoaded", function () {
    document.querySelectorAll(".toggle-link").forEach(function (link) {
        link.addEventListener("click", function (e) {
            e.preventDefault();
            const content = this.previousElementSibling;
            if (content.classList.contains("text-truncate")) {
                content.classList.remove("text-truncate");
                content.style.maxHeight = "none";
                this.textContent = "Show less";
            } else {
                content.classList.add("text-truncate");
                content.style.maxHeight = "100px";
                this.textContent = "Show more";
            }
        });
    });
});