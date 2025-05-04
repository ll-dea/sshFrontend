// indexController.js
document.addEventListener("DOMContentLoaded", () => {
    const orders = JSON.parse(localStorage.getItem("recentOrders")) || [];
    const tbody = document.getElementById("recentOrders");

    orders.forEach((order) => {
        const row = document.createElement("tr");
        row.innerHTML = `
      <td>${order.florist}</td>
      <td>${order.date} ${order.time}</td>
      <td><span class="status ${order.status.toLowerCase()}">${order.status}</span></td>
    `;
        tbody.appendChild(row);
    });
});
