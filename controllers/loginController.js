// loginController.js
import vest, { validate, enforce } from "https://cdn.skypack.dev/vest";

document.addEventListener("DOMContentLoaded", () => {
    const form = document.getElementById("loginForm");

    form.addEventListener("submit", (e) => {
        e.preventDefault();
        const username = document.getElementById("username").value.trim();
        const password = document.getElementById("password").value.trim();

        const result = validate("loginForm", () => {
            enforce(username).isNotEmpty().message("Username is required");
            enforce(password).isNotEmpty().message("Password is required");
        });

        if (result.hasErrors()) {
            alert("Please fill in both fields");
            return;
        }

        const storedUser = JSON.parse(localStorage.getItem("user"));
        if (storedUser?.username === username && storedUser?.password === password) {
            localStorage.setItem("loggedIn", "true");
            window.location.href = "index.html";
        } else {
            alert("Invalid credentials");
        }
    });
});
