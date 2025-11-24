using FribergsCarRentalsAB.Data;
using FribergsCarRentalsAB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FribergsCarRentalsAB.Controllers
{
    public class AdminController : Controller
    {

        public async Task<IActionResult> Index()
        {
            return View();
        }


    }
}
