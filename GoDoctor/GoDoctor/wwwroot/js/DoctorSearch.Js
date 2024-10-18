async function getDoctors(page) {
    const specialty = document.getElementById('specialty').value;
    const governorate = document.getElementById('governorate').value;
    const doctor = document.getElementById('doctor').value;

    try {
        const response = await fetch(`https://localhost:44326/Doctor/ViewDoctors1?specialty=${specialty}&governorate=${governorate}&doctor=${doctor}&page=${page}`, {
            method: 'GET',
            credentials: 'include'
        });

        if (!response.ok) {
            const errorData = await response.json();
            document.getElementById("ParentCard").innerHTML = `<p class="text-danger">${errorData.message}</p>`;
            return;
        }

        const data = await response.json();
        renderDoctors(data.data);
        renderPagination(data.data.totalPages, data.data.CurrentPage);
    } catch (error) {
        console.error('An error occurred:', error);
    }
}

function renderDoctors(doctors) {
    const parentCard = document.getElementById("ParentCard");
    parentCard.innerHTML = `
        <div class="row row-cols-1 row-cols-md-2 row-cols-lg-3 g-4">
            ${doctors.map(doctor => `
                <div class="col mb-4">
                    <div class="card h-100 shadow-sm">
                        <img src="${doctor.image}" alt="${doctor.name}" class="card-img-top" style="height: 250px; object-fit: contain;">
                        <div class="card-body">
                            <h5 class="card-title text-primary">${doctor.name}</h5>
                            <h6 class="card-subtitle mb-2 text-muted">${doctor.specialtyName}</h6>
                            <p class="card-text">${doctor.description}</p>
                        </div>
                        <div class="card-footer bg-transparent">
                            <div class="d-flex justify-content-between">
                                <a href="/Doctor/Details/${doctor.id}" class="btn btn-outline-primary btn-lg px-4 py-2 rounded text-center flex-grow-1 me-2 shadow-sm" 
                                    style="font-size: 1rem; white-space: normal;">View<br>Profile</a>
                                <a href="/Appointment/ViewAllAppointmen?doctorId=${doctor.id}" class="btn btn-primary btn-lg px-4 py-2 rounded shadow-sm flex-grow-1" 
                                    style="font-size: 1rem;">Book Appointment</a>
                            </div>
                        </div>
                    </div>
                </div>
            `).join('')}
        </div>
    `;
}

function formatDoctorName(name) {
    // Splits the doctor's name by space and adds a non-breaking space (&nbsp;) between first and last name
    const nameParts = name.split(' ');
    if (nameParts.length >= 2) {
        return `${nameParts[0]}&nbsp;${nameParts.slice(1).join(' ')}`;
    }
    return name; // Return the name as-is if it doesn't have a space
}

function renderPagination(totalPages, currentPage) {
    const pagination = document.getElementById('pagination-container');
    pagination.innerHTML = `
        <nav aria-label="Page navigation" class="mt-4">
            <ul class="pagination justify-content-center">
                <li class="page-item ${currentPage === 1 ? 'disabled' : ''}">
                    <a class="page-link" href="#" onclick="getDoctors(${currentPage - 1}); return false;" aria-label="Previous">
                        <span aria-hidden="true">&laquo;</span>
                    </a>
                </li>
                ${Array.from({ length: totalPages }, (_, i) => i + 1).map(page => `
                    <li class="page-item ${page === currentPage ? 'active' : ''}">
                        <a class="page-link" href="#" onclick="getDoctors(${page}); return false;">${page}</a>
                    </li>
                `).join('')}
                <li class="page-item ${currentPage === totalPages ? 'disabled' : ''}">
                    <a class="page-link" href="#" onclick="getDoctors(${currentPage + 1}); return false;" aria-label="Next">
                        <span aria-hidden="true">&raquo;</span>
                    </a>
                </li>
            </ul>
        </nav>
    `;
}

document.getElementById('submit').addEventListener('click', (event) => {
    event.preventDefault();
    getDoctors(1);
});

// Initial data fetch
getDoctors(1);
