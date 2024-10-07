async function getDoctors(page) {
    let specialty = document.getElementById('specialty').value;
    let governorate = document.getElementById('governorate').value;
    let doctor = document.getElementById('doctor').value;
    //let page = 1;
    console.log('Specialty:', specialty);
    console.log('Governorate:', governorate);
    console.log('Doctor:', doctor);
    
    let result = await fetch(`https://localhost:44326/Doctor/ViewDoctors1?specialty=${specialty}&governorate=${governorate}&doctor=${doctor}&page=${page}`, {
        method: 'GET',
        credentials: 'include'
    });

    if (!result.ok) {
        // Handle not found or error response
        const errorData = await result.json();
        const parentCard = document.getElementById("ParentCard");
        parentCard.innerHTML = `<p>${errorData.massage}</p>`;
        return;
    }

    let data = await result.json();
    renderDoctors(data.data);
    MakePagination(data.data.totalPages,data.data.CurrentPage,10)
}

function renderDoctors(doctors) {
    const parentCard = document.getElementById("ParentCard");
    parentCard.innerHTML = ''; // Clear previous results

    doctors.forEach(doctor => {
        const card = `
    <div class="card m-2 shadow-sm col-lg-4 col-md-6 mb-4 rounded border-0">
        <img src="${doctor.image}" alt="${doctor.name}" class="card-img-top rounded-top">
        <div class="card-body">
            <h3 class="card-title text-primary">${doctor.name}</h3>
            <h5 class="card-subtitle mb-2 text-muted">${doctor.specialtyName}</h5>
            <p class="card-text">${doctor.specialtyDescription}</p>
            <p class="card-text">${doctor.description}</p>
        </div>
        <div class="card-footer text-center bg-transparent border-0">
            <a href="/ControllerName/GoAsDoctor?id=${doctor.id}" class="btn btn-outline-primary btn-sm">View Doctor</a>
        </div>
    </div>`;

        parentCard.innerHTML += card;
    });
}

// Wrap your function calls in an async function to use await
async function fetchDataAndRender() {
    try {
        await getDoctors(1);
    } catch (error) {
        console.error('An error occurred:', error);
    }
}

// Call the async function to fetch and render data
fetchDataAndRender();

document.getElementById('submit').addEventListener('click', async (event) => {
    event.preventDefault(); // Prevent default form submission behavior

    // Call the async function to fetch and render data
    await fetchDataAndRender();
});
async function goToPage(i) {
    await getDoctors(i);
}
function MakePagination(totalItems, currentPage, pageSize) {
    // Calculate total pages
    const totalPages = Math.ceil(totalItems / pageSize);

    // Initialize an empty array to store pagination elements
    const pagination = [];

    // Add a "Previous" button, disabled if on the first page
    if (currentPage > 1) {
        pagination.push(`<button onclick="goToPage(${currentPage - 1})">Previous</button>`);
    } else {
        pagination.push(`<button disabled>Previous</button>`);
    }

    // Loop through the total number of pages to add page numbers
    for (let i = 1; i <= totalPages; i++) {
        // Add the current page with an active state
        if (i === currentPage) {
            pagination.push(`<button class="active">${i}</button>`);
        } else {
            pagination.push(`<button onclick="goToPage(${i})">${i}</button>`);
        }
    }

    // Add a "Next" button, disabled if on the last page
    if (currentPage < totalPages) {
        pagination.push(`<button onclick="goToPage(${currentPage + 1})">Next</button>`);
    } else {
        pagination.push(`<button disabled>Next</button>`);
    }

    // Join the pagination array to form a single string and insert it into the DOM
    document.getElementById('pagination-container').innerHTML = pagination.join(' ');
}


