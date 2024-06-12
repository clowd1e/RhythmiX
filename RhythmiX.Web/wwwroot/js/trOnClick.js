document.addEventListener("DOMContentLoaded", function () {
    let rows = document.querySelectorAll(".clickable-row");
    rows.forEach(function (row) {
        row.addEventListener("click", function () {
            let url = this.dataset.url;
            window.location.href = url;
        });
    });
});