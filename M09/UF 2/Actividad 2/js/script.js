let right = document.querySelector('.right');
let left = document.querySelector('.left');

// Define the pages in order
const pages = ["index.html","wav.html", "ogg.html", "flac.html", "opus.html"];

// Get the current page index
let currentPage = pages.indexOf(window.location.pathname.split("/").pop());

right.addEventListener("click", () => {
    if (currentPage < pages.length - 1) {
        window.location.href = pages[currentPage + 1];
    }
});

left.addEventListener("click", () => {
    if (currentPage > 0) {
        window.location.href = pages[currentPage - 1];
    }
});
