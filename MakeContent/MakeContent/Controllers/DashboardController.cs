using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeContentUI.Controllers
{
    public class DashboardController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return RedirectToAction(nameof(Earnings));
        }
        public async Task<IActionResult> Earnings()
        {
            return View();
        }
    }
}
