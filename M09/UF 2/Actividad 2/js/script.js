let right = document.querySelector('.right');
let left = document.querySelector('.left');

// Define the pages in order
const pages = ["index.html", "flac.html", "opus.html", "ogg.html", "mp3.html"];

// Get the current page index
let currentPage = pages.indexOf(window.location.pathname.split("/").pop());

right.addEventListener("click", () => {
    if (currentPage === pages.length - 1) {
        // If on the last page (mp3.html), go to the first page (index.html)
        window.location.href = pages[0];
    } else {
        window.location.href = pages[currentPage + 1];
    }
});

left.addEventListener("click", () => {
    if (currentPage === 0) {
        // If on the first page (index.html), go to the last page (mp3.html)
        window.location.href = pages[pages.length - 1];
    } else {
        window.location.href = pages[currentPage - 1];
    }
});
