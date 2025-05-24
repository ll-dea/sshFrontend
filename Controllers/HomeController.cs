using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SSH_FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
namespace SSH_FrontEnd.Controllers;



public class HomeController : Controller
{
    public IActionResult Index()
    {
        if (!User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Login", "Auth");
        }

        var role = User.FindFirst(ClaimTypes.Role)?.Value?.ToLower();

        if (role == "admin")
        {
            return RedirectToAction("Index","Admin");
        }
        else if (role == "client")
        {
            return RedirectToAction("Dashboard", "Client");
        }

        return RedirectToAction("Login", "Auth"); // fallback
    }
}

