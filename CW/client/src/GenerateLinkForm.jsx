import { useState } from 'react';

const GenerateLinkForm = () => {
    const [id, setId] = useState('');
    const [link, setLink] = useState('');
    const [shortenLink, setShortenLink] = useState('');

    const handleSubmit = async (event) => {
        event.preventDefault();

        const userLink = { id, link, shortenLink };

        try {
            const response = await fetch('https://localhost:5249/userlink/create', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(userLink)
            });

            if (response.ok) {
                const result = await response.json();
                alert('Link generated successfully: ' + JSON.stringify(result));
            } else {
                alert('Failed to generate link: ' + response.statusText);
            }
        } catch (error) {
            console.error('Error:', error);
            alert('Error generating link');
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <div>
                <label htmlFor="id">ID:</label>
                <input
                    type="number"
                    id="id"
                    value={id}
                    onChange={(e) => setId(e.target.value)}
                    required
                />
            </div>
            <div>
                <label htmlFor="link">Link:</label>
                <input
                    type="text"
                    id="link"
                    value={link}
                    onChange={(e) => setLink(e.target.value)}
                    required
                />
            </div>
            <div>
                <label htmlFor="shortenLink">Shorten Link:</label>
                <input
                    type="text"
                    id="shortenLink"
                    value={shortenLink}
                    onChange={(e) => setShortenLink(e.target.value)}
                    required
                />
            </div>
            <button type="submit">Generate Link</button>
        </form>
    );
};

export default GenerateLinkForm;
