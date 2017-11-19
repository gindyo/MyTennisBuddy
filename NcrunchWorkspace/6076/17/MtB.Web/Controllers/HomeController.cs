using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MtB.BuddyList.Plugins;

namespace MtB.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProvideBuddies _buddiesProvider;

        public HomeController(IProvideBuddies buddiesProvider)
        {
            _buddiesProvider = buddiesProvider;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
