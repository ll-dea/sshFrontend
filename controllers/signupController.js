document.addEventListener("DOMContentLoaded", () => {
    const form = document.getElementById("signupForm");

    form.addEventListener("submit", (e) => {
        e.preventDefault();

        const email = document.getElementById("email").value.trim();
        const username = document.getElementById("username").value.trim();
        const password = document.getElementById("password").value;

        // Validime të thjeshta
        if (!email || !username || !password) {
            alert("Të gjitha fushat janë të detyrueshme!");
            return;
        }

        // Mund të zëvendësosh këtë me regjistrim në backend më vonë
        const user = { email, username, password };
        localStorage.setItem("user", JSON.stringify(user));
        localStorage.setItem("loggedIn", "false");

        alert("Përdoruesi u regjistrua me sukses!");
        window.location.href = "login.html";
    });
});
