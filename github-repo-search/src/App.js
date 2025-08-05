import React, { useState } from 'react';

function App() {
  const [query, setQuery] = useState('');
  const [results, setResults] = useState([]);
  const [loading, setLoading] = useState(false);
  const [emailPopupOpen, setEmailPopupOpen] = useState(false);
  const [selectedRepo, setSelectedRepo] = useState(null);
  const [email, setEmail] = useState('');
  const [sendingEmail, setSendingEmail] = useState(false);

  const searchRepos = async () => {
    if (!query) return;

    setLoading(true);
    try {
      const response = await fetch(`https://localhost:7142/api/github/search?query=${query}`);
      if (!response.ok) throw new Error('Network response was not ok');
      const data = await response.json();
      setResults(data.items || []);
    } catch (error) {
      alert('Error fetching data');
      console.error(error);
    }
    setLoading(false);
  };

  const handleKeyPress = (e) => {
    if (e.key === 'Enter') {
      searchRepos();
    }
  };

  const handleBookmark = async (repo) => {
    try {
      const response = await fetch('https://localhost:7142/api/bookmarks/bookmark', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        credentials: 'include', // חשוב אם משתמשים בסשן
        body: JSON.stringify({
          id: repo.id.toString(),
          name: repo.name,
          ownerLogin: repo.owner.login,
          avatarUrl: repo.owner.avatar_url,
          htmlUrl: repo.html_url,
        }),
      });

      if (response.ok) {
        alert('Bookmarked!');
      } else if (response.status === 409) {
        alert('Already bookmarked');
      } else {
        const text = await response.text();
        alert(`Bookmark failed: ${text}`);
      }
    } catch (error) {
      console.error('Error bookmarking repo:', error);
    }
  };

  const openEmailPopup = (repo) => {
    setSelectedRepo(repo);
    setEmail('');
    setEmailPopupOpen(true);
  };

  const closeEmailPopup = () => {
    setEmailPopupOpen(false);
    setSelectedRepo(null);
  };

  const sendEmail = async () => {
    if (!email) {
      alert('Please enter an email address');
      return;
    }

    setSendingEmail(true);

    try {
      const response = await fetch('https://localhost:7142/api/email/send-email', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({
          email,
          repoName: selectedRepo.name,
          ownerLogin: selectedRepo.owner.login,
          repoUrl: selectedRepo.html_url,
        }),
      });

      if (response.ok) {
        alert('Email sent!');
        closeEmailPopup();
      } else {
        const text = await response.text();
        alert(`Failed to send email: ${text}`);
      }
    } catch (error) {
      console.error('Error sending email:', error);
      alert('Error sending email');
    }

    setSendingEmail(false);
  };

  return (
    <div style={{ padding: '20px' }}>
      <h1>GitHub Repo Search</h1>
      <input
        type="text"
        value={query}
        onChange={(e) => setQuery(e.target.value)}
        onKeyPress={handleKeyPress}
        placeholder="Type repository name"
        style={{ width: '300px', padding: '8px' }}
      />
      <button onClick={searchRepos} disabled={loading} style={{ marginLeft: '10px', padding: '8px 12px' }}>
        {loading ? 'Searching...' : 'Search'}
      </button>

      <div style={{ marginTop: '20px' }}>
        {results.length === 0 && !loading && <p>No results</p>}
        <div style={{ display: 'flex', flexWrap: 'wrap', gap: '15px' }}>
          {results.map((repo) => (
            <div key={repo.id} style={{ border: '1px solid #ccc', padding: '10px', width: '300px' }}>
              <h3>{repo.name}</h3>
              <img src={repo.owner.avatar_url} alt="Owner avatar" style={{ width: '50px', borderRadius: '50%' }} />
              <p>👤 {repo.owner.login}</p>
              <a href={repo.html_url} target="_blank" rel="noreferrer">View on GitHub</a>
              <div style={{ marginTop: '10px' }}>
                <button onClick={() => handleBookmark(repo)} style={{ marginRight: '10px' }}>📌 Bookmark</button>
                <button onClick={() => openEmailPopup(repo)}>✉️ Send Email</button>
              </div>
            </div>
          ))}
        </div>
      </div>

      {emailPopupOpen && (
        <div style={{
          position: 'fixed', top: 0, left: 0, right: 0, bottom: 0,
          backgroundColor: 'rgba(0,0,0,0.5)', display: 'flex',
          justifyContent: 'center', alignItems: 'center'
        }}>
          <div style={{ backgroundColor: 'white', padding: '20px', borderRadius: '5px', width: '300px' }}>
            <h3>Send Repository Details</h3>
            <p><strong>{selectedRepo.name}</strong> by {selectedRepo.owner.login}</p>
            <input
              type="email"
              placeholder="Enter email"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              style={{ width: '100%', padding: '8px', marginBottom: '10px' }}
            />
            <button onClick={sendEmail} disabled={sendingEmail} style={{ marginRight: '10px' }}>
              {sendingEmail ? 'Sending...' : 'Send'}
            </button>
            <button onClick={closeEmailPopup}>Cancel</button>
          </div>
        </div>
      )}
    </div>
  );
}

export default App;
