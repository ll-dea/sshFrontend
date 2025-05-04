document.addEventListener("DOMContentLoaded", () => {
    const modal = document.getElementById("bookingModal");
    const closeModalBtn = document.getElementById("closeModal");
    const confirmBookingBtn = document.getElementById("confirmBooking");

    // Hap modalin kur klikohet një buton "Book"
    document.querySelectorAll(".book-btn").forEach((button) => {
        button.addEventListener("click", () => {
            const card = button.closest(".venue-card");
            const venueName = card.querySelector(".venue-info h4").innerText;

            localStorage.setItem("selectedVenue", venueName);
            modal.style.display = "flex";
        });
    });

    // Mbyll modalin
    closeModalBtn.addEventListener("click", () => {
        modal.style.display = "none";
    });

    // Konfirmo prenotimin
    confirmBookingBtn.addEventListener("click", () => {
        const date = document.getElementById("date").value;
        const time = document.getElementById("time").value;
        const venueName = localStorage.getItem("selectedVenue");

        if (date && time && venueName) {
            const newOrder = {
                venue: venueName,
                date: date,
                time: time,
                status: "Pending",
            };

            const existingOrders = JSON.parse(localStorage.getItem("recentOrders")) || [];
            existingOrders.push(newOrder);
            localStorage.setItem("recentOrders", JSON.stringify(existingOrders));

            alert(`Booking confirmed for ${date} at ${time} at ${venueName}`);
            modal.style.display = "none";
        } else {
            alert("Please select both a date and time!");
        }
    });
});
