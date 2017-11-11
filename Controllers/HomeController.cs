using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using convertizzle.Models;

namespace convertizzle.Controllers
{
    public class HomeController : Controller
    {
        CCContext _context;

        public HomeController(CCContext context) {
            _context = context;
        }

        public IActionResult Index()
        {
            var account = _context.Accounts.First();
            
            ViewData["Email"] = account.Email;

            return View();
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
