// musicController.js
document.addEventListener("DOMContentLoaded", () => {
    const bookButtons = document.querySelectorAll(".book-btn");
    const modal = document.getElementById("bookingModal");
    const confirmBookingBtn = document.getElementById("confirmBooking");
    const closeModalBtn = document.getElementById("closeModal");

    // Show modal
    bookButtons.forEach((button) => {
        button.addEventListener("click", () => {
            const card = button.closest(".music-card");
            const musicName = card.querySelector(".music-info h4").innerText;
            localStorage.setItem("selectedMusic", musicName);
            modal.style.display = "flex";
        });
    });

    // Close modal
    closeModalBtn.addEventListener("click", () => {
        modal.style.display = "none";
    });

    // Confirm booking
    confirmBookingBtn.addEventListener("click", async () => {
        const date = document.getElementById("date").value;
        const time = document.getElementById("time").value;
        const musicName = localStorage.getItem("selectedMusic");

        // Import Vest dynamically
        const vest = await import("https://cdn.skypack.dev/vest");

        const suite = vest.create("bookingForm", () => {
            vest.enforce(date).isNotEmpty().message("Date is required");
            vest.enforce(time).isNotEmpty().message("Time is required");
        });

        const result = suite.get();

        if (result.hasErrors()) {
            alert("Please fill in all fields!");
            return;
        }

        const booking = {
            music: musicName,
            date,
            time,
            status: "Pending",
        };

        const existing = JSON.parse(localStorage.getItem("recentOrders")) || [];
        existing.push(booking);
        localStorage.setItem("recentOrders", JSON.stringify(existing));
        alert(`Booked ${musicName} on ${date} at ${time}`);
        modal.style.display = "none";
    });
});
