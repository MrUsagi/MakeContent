using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeContentUI.Controllers
{
    public class EditController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Basics()
        {
            return PartialView();
        }

        public async Task<IActionResult> Tiers()
        {
            return PartialView();
        }

        public async Task<IActionResult> Merch()
        {
            return PartialView();
        }

        public async Task<IActionResult> Paid()
        {
            return PartialView();
        }

        public async Task<IActionResult> Settings()
        {
            return PartialView();
        }

        public async Task<IActionResult> Preview()
        {
            return PartialView();
        }

        public async Task<IActionResult> Welcome()
        {
            return PartialView();
        }

        public async Task<IActionResult> Goals()
        {
            return PartialView();
        }

        public async Task<IActionResult> Offers()
        {
            return PartialView();
        }
    }
}
