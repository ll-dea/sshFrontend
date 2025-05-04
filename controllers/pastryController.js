// pastryController.js
document.addEventListener("DOMContentLoaded", () => {
    const bookButtons = document.querySelectorAll(".book-btn");
    const modal = document.getElementById("bookingModal");
    const confirmBookingBtn = document.getElementById("confirmBooking");
    const closeModalBtn = document.getElementById("closeModal");

    // Show modal on "Book" click
    bookButtons.forEach((button) => {
        button.addEventListener("click", () => {
            const card = button.closest(".pastry-card");
            const pastryName = card.querySelector(".pastry-info h4").innerText;
            localStorage.setItem("selectedPastry", pastryName);
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
        const pastryName = localStorage.getItem("selectedPastry");

        // Use Vest for validation
        const { validate } = await import("https://cdn.skypack.dev/vest");
        const suite = validate("bookingForm", () => {
            vest.enforce(date).isNotEmpty().message("Date is required");
            vest.enforce(time).isNotEmpty().message("Time is required");
        });

        if (suite.hasErrors()) {
            alert("Please fill in all fields!");
            return;
        }

        const booking = {
            pastry: pastryName,
            date,
            time,
            status: "Pending",
        };

        const existing = JSON.parse(localStorage.getItem("recentOrders")) || [];
        existing.push(booking);
        localStorage.setItem("recentOrders", JSON.stringify(existing));

        alert(`Booked ${pastryName} on ${date} at ${time}`);
        modal.style.display = "none";
    });
});
