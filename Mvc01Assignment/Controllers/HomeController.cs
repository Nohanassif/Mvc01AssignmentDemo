using Microsoft.AspNetCore.Mvc;
using Mvc01Assignment.Models;
using System.Diagnostics;

namespace Mvc01Assignment.Controllers
{
    public class HomeController : Controller
    {
        //Action
        //BaseUrl/Home/Index
        //BaseUrl/Home
        //Master action
        //Default method for action --> GET
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
