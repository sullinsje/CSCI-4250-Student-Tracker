'use strict';

async function testProtectedEndpoint() {
    const fetchUrl = 'http://localhost:5050/api/Student/all';

    const response = await fetch(fetchUrl, {
        method: 'GET',
        credentials: 'include'
    });

    if (response.ok) {
        const data = await response.json();
        console.log('✅ Access Granted. Student Data:', data);

    }
}

window.onload = testProtectedEndpoint;