# GitHub Repository Search and Email Sender

## Overview

This project is a full-stack application that allows users to:  
- Search for GitHub repositories by name  
- Bookmark repositories  
- Send repository details via email  

The frontend is built with React, and the backend is a .NET Web API.

---

## Project Structure

- **Frontend:** React application that provides the user interface for searching GitHub repositories, bookmarking them, and sending repository details by email.  
- **Backend:** ASP.NET Core Web API responsible for GitHub search, storing bookmarks in session, and sending emails.  
- **PART1+2 Folder:** Contains the initial parts of the test, including foundational exercises and backend code snippets from the first and second parts of the assignment.

---

## Setup Instructions

### Backend (.NET API)

1. **Email Configuration:**  
   Configure your SMTP settings in `appsettings.json` under the `EmailSettings` section:

   ```json
   "EmailSettings": {
     "SmtpServer": "smtp.yourserver.com",
     "SmtpPort": 587,
     "SenderEmail": "your-email@example.com",
     "SenderPassword": "your-email-password"
   }
Session Configuration:
The backend uses session storage to keep bookmarks. Make sure that session and distributed cache services are registered and configured in Program.cs.

CORS Policy:
Enable CORS to allow requests from the React frontend URLs and support credentials.

Running the Backend:
Run the ASP.NET Core Web API on your machine (default URL assumed: https://localhost:7142).

Frontend (React)
Install dependencies:
Navigate to the React project folder and run:

npm install
Run the React app:

npm start
Functionality
Search for GitHub repositories by name.

Bookmark repositories (stored in server session).

Send repository details via email.

Notes
Bookmarks are stored in the server session, so they are specific to the user session and will be lost if the session expires or the server restarts.

Email sending requires valid SMTP configuration.

Sensitive information such as email passwords should be stored securely and never committed to public repositories.

The PART1+2 folder contains the initial parts of the test for reference.

How to Test
Run the backend API.

Run the frontend React app.

Search for GitHub repositories using the search bar.

Bookmark repositories and verify the bookmarks via the API endpoint or the UI.

Use the "Send Email" button to email repository details to a valid email address.

Contact
For any questions or issues, please reach out to:
avigail7239@gmail.com