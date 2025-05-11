// Aktivizimi i menuse në sidebar
const allSideMenu = document.querySelectorAll("#sidebar .side-menu.top li a");

allSideMenu.forEach((item) => {
    const li = item.parentElement;
    item.addEventListener("click", function () {
        allSideMenu.forEach((i) => {
            i.parentElement.classList.remove("active");
        });
        li.classList.add("active");
    });
});

// Toggle i sidebar-it
const menuBar = document.querySelector("#content nav .bx.bx-menu");
const sidebar = document.getElementById("sidebar");

menuBar?.addEventListener("click", function () {
    sidebar.classList.toggle("hide");
});

// Search button për mobile
const searchButton = document.querySelector("#content nav form .form-input button");
const searchButtonIcon = document.querySelector("#content nav form .form-input button .bx");
const searchForm = document.querySelector("#content nav form");

searchButton?.addEventListener("click", function (e) {
    if (window.innerWidth < 576) {
        e.preventDefault();
        searchForm.classList.toggle("show");
        if (searchForm.classList.contains("show")) {
            searchButtonIcon.classList.replace("bx-search", "bx-x");
        } else {
            searchButtonIcon.classList.replace("bx-x", "bx-search");
        }
    }
});

if (window.innerWidth < 768) {
    sidebar?.classList.add("hide");
} else if (window.innerWidth > 576) {
    searchButtonIcon?.classList.replace("bx-x", "bx-search");
    searchForm?.classList.remove("show");
}

window.addEventListener("resize", function () {
    if (this.innerWidth > 576) {
        searchButtonIcon?.classList.replace("bx-x", "bx-search");
        searchForm?.classList.remove("show");
    }
});

// Dark mode switch
const switchMode = document.getElementById("switch-mode");
switchMode?.addEventListener("change", function () {
    document.body.classList.toggle("dark", this.checked);
});

// Check if the user is logged in before allowing actions (optional)
//if (!localStorage.getItem("loggedIn") || localStorage.getItem("loggedIn") !== "true") {
    // User is not logged in, redirect to a safe page or show an error (You can remove this entirely if you don't need any redirect)
  //  window.location.href = "#"; // Prevents redirection to login/signup pages
//}

// LOGOUT
//document.querySelector(".logout")?.addEventListener("click", function (e) {
  //  e.preventDefault();
    //localStorage.removeItem("loggedIn");
    //window.location.href = "#"; // Ensures that there is no redirect to login/signup pages after logout
//});

// Modal
const modal = document.getElementById("addEventModal");
const openModalBtn = document.getElementById("openModalBtn");
const closeModal = document.querySelector(".modal .close");

openModalBtn?.addEventListener("click", () => {
    modal.style.display = "block";
});

closeModal?.addEventListener("click", () => {
    modal.style.display = "none";
});

window.addEventListener("click", (event) => {
    if (event.target === modal) {
        modal.style.display = "none";
    }
});

// Forma per shtimin e eventit
const addEventForm = document.getElementById("addEventForm");
const recentOrdersTable = document.getElementById("recentOrders");

function loadEventsToUserDashboard() {
    const events = JSON.parse(localStorage.getItem("recentOrders")) || [];
    if (!recentOrdersTable) return;

    recentOrdersTable.innerHTML = "";
    events
        .slice()
        .reverse()
        .forEach((event) => {
            const tr = document.createElement("tr");
            tr.innerHTML = `
      <td>${event.name}</td>
      <td>${event.type}</td>
      <td>${event.date}</td>
      <td><span class="status ${event.status.toLowerCase()}">${event.status
                }</span></td>
    `;
            recentOrdersTable.appendChild(tr);
        });
}

function loadEventsToMyEventsPage() {
    const events = JSON.parse(localStorage.getItem("recentOrders")) || [];
    const eventListTable = document.getElementById("eventListTable");
    if (!eventListTable) return;

    eventListTable.innerHTML = "";
    events
        .slice()
        .reverse()
        .forEach((event) => {
            const tr = document.createElement("tr");
            tr.innerHTML = `
      <td>${event.name}</td>
      <td>${event.date}</td>
      <td>${event.type}</td>
      <td><span class="status ${event.status.toLowerCase()}">${event.status
                }</span></td>
    `;
            eventListTable.appendChild(tr);
        });
}

// Add Event
addEventForm?.addEventListener("submit", (e) => {
    e.preventDefault();

    const name = document.getElementById("eventName").value;
    let date = document.getElementById("eventDate").value;
    const eventTypeId = document.getElementById("eventTypeId").value;

    date = date.replace("T", " ");

    const eventTypes = {
        1: "Wedding",
        2: "Birthday",
        3: "Conference",
    };

    const newEvent = {
        name,
        date,
        status: "Pending",
        type: eventTypes[eventTypeId],
    };

    const events = JSON.parse(localStorage.getItem("recentOrders")) || [];
    events.push(newEvent);
    localStorage.setItem("recentOrders", JSON.stringify(events));

    modal.style.display = "none";
    addEventForm.reset();
    loadEventsToUserDashboard();
});

// Seed sample
if (!localStorage.getItem("recentOrders")) {
    const sampleEvents = [
        {
            name: "Wedding Ceremony",
            date: "2025-05-02 15:00",
            status: "Pending",
            type: "Wedding",
        },
        {
            name: "Birthday Party",
            date: "2025-05-10 18:30",
            status: "Confirmed",
            type: "Birthday",
        },
    ];
    localStorage.setItem("recentOrders", JSON.stringify(sampleEvents));
}

window.addEventListener("load", () => {
    loadEventsToUserDashboard();
    loadEventsToMyEventsPage();
});
