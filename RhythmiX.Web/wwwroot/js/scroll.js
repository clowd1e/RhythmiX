function changeCss() {
    let element = $("#search-bar");
    this.scrollY > 100 ? element.css('background-color', '#090909') : element.css('background-color', '#171717');
}

window.addEventListener("scroll", changeCss, false);