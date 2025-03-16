let currentImageIndex = 0;
const images = document.querySelectorAll('.slider-images img');

function showImage(index) {
    // Hide all images
    images.forEach((img) => img.classList.remove('active'));

    // Show the current image
    images[index].classList.add('active');
}

function nextImage() {
    currentImageIndex = (currentImageIndex + 1) % images.length;
    showImage(currentImageIndex);
}

function prevImage() {
    currentImageIndex = (currentImageIndex - 1 + images.length) % images.length;
    showImage(currentImageIndex);
}

// Show the first image initially
showImage(currentImageIndex);
