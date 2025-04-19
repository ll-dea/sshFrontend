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

// TOGGLE SIDEBAR
const menuBar = document.querySelector("#content nav .bx.bx-menu");
const sidebar = document.getElementById("sidebar");

menuBar.addEventListener("click", function () {
    sidebar.classList.toggle("hide");
});

const searchButton = document.querySelector(
    "#content nav form .form-input button"
);
const searchButtonIcon = document.querySelector(
    "#content nav form .form-input button .bx"
);
const searchForm = document.querySelector("#content nav form");

searchButton.addEventListener("click", function (e) {
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
    sidebar.classList.add("hide");
} else if (window.innerWidth > 576) {
    searchButtonIcon.classList.replace("bx-x", "bx-search");
    searchForm.classList.remove("show");
}

window.addEventListener("resize", function () {
    if (this.innerWidth > 576) {
        searchButtonIcon.classList.replace("bx-x", "bx-search");
        searchForm.classList.remove("show");
    }
});

const switchMode = document.getElementById("switch-mode");

switchMode.addEventListener("change", function () {
    if (this.checked) {
        document.body.classList.add("dark");
    } else {
        document.body.classList.remove("dark");
    }
});

// Pasi të ngarkohet faqja, kontrolloni nëse ka rezervime të ruajtura
window.addEventListener("load", function () {
    const recentOrder = localStorage.getItem("recentOrder");
    if (recentOrder) {
        const order = JSON.parse(recentOrder);

        // Gjeni elementin e tabelës dhe shtoni rreshtin për rezervimin
        const tbody = document.getElementById("recentOrders");
        const newRow = document.createElement("tr");

        newRow.innerHTML = `
		<td><img src="img/people.png" /><p>Anonymous</p></td>
		<td>${order.date} at ${order.time}</td>
		<td><span class="status completed">Completed</span></td>
	  `;

        tbody.appendChild(newRow);

        // Pasi të shtoni rezervimin, mund të fshini atë nga localStorage
        localStorage.removeItem("recentOrder");
    }
});

// Kontrollo nëse përdoruesi është loguar
const isLoggedIn = localStorage.getItem("loggedIn");
const user = localStorage.getItem("user");

if (!user) {
    // Nëse nuk ka user të regjistruar fare, dërgo te signup
    window.location.href = "signup.html";
} else if (isLoggedIn !== "true") {
    // Nëse është regjistruar por jo i loguar, dërgo te login
    window.location.href = "login.html";
}

// LOGOUT button
document.querySelector(".logout")?.addEventListener("click", function (e) {
    e.preventDefault();
    localStorage.removeItem("loggedIn");
    window.location.href = "login.html";
});

document.addEventListener("DOMContentLoaded", function () {
    const isLoggedIn = localStorage.getItem("loggedIn");

    if (!isLoggedIn || isLoggedIn !== "true") {
        window.location.href = "signup.html"; // ose "login.html" nëse preferon
    }
});

document.addEventListener("DOMContentLoaded", function () {
    const orders = JSON.parse(localStorage.getItem("recentOrders")) || [];
    const tbody = document.querySelector(".order table tbody");

    // Pastro rreshtat ekzistues në tabelë
    tbody.innerHTML = "";

    // Shto rezervimet në tabelë
    orders
        .slice(-5)
        .reverse()
        .forEach((order) => {
            const tr = document.createElement("tr");

            tr.innerHTML = `
  <td>
  <img src="img/logo.png" />
  <p>${order.florist}</p>
  </td>
  <td>${order.date} at ${order.time}</td>
  <td><span class="status pending">${order.status}</span></td>
`;

            tbody.appendChild(tr);
        });
});
