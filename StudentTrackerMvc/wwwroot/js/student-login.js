'use strict';

const loginForm = document.getElementById('login-form');

loginForm.addEventListener('submit', (e) => {
    e.preventDefault();
    processFormData();
});


async function processFormData() {
    const form = document.getElementById('login-form');
    const formData = new FormData(form);

    const usernameValue = formData.get('username');
    const passwordValue = formData.get('password');

    const user = {
        email: usernameValue,
        password: passwordValue
    }

    const fetchUrl = 'http://localhost:5050/login';

    const response = await fetch(fetchUrl, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json' // Tell the server to expect JSON
        },
        body: JSON.stringify(user), // Convert object to JSON string
    });

    if (response.ok) {
        const tokenData = await response.json();
        const accessToken = tokenData.accessToken;
        localStorage.setItem('authToken', accessToken); // Store the token
        window.location.href = '/student/student';     // Redirect

    } else {
        const errorData = await response.json();
        console.error('Login failed:', errorData);
    }
}