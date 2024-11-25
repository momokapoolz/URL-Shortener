document.getElementById('urlForm').addEventListener('submit', function (event) {
    event.preventDefault();

    const originalUrl = document.getElementById('originalUrl').value;
    const loadingDiv = document.getElementById('loading');
    const errorDiv = document.getElementById('error');
    const shortenedUrlDiv = document.getElementById('shortenedUrl');

    loadingDiv.style.display = 'block';
    errorDiv.style.display = 'none';
    shortenedUrlDiv.innerText = '';

    fetch('/api/userlinks/create', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ Link: originalUrl })
    })
        .then(response => response.json())
        .then(data => {
            loadingDiv.style.display = 'none';
            if (data.ShortenLink) {
                shortenedUrlDiv.innerText = `Shortened URL: ${data.ShortenLink}`;
            } else {
                errorDiv.innerText = 'Failed to shorten the URL.';
                errorDiv.style.display = 'block';
            }
        })
        .catch(error => {
            loadingDiv.style.display = 'none';
            errorDiv.innerText = 'An error occurred: ' + error.message;
            errorDiv.style.display = 'block';
            console.error('Error:', error);
        });
});


