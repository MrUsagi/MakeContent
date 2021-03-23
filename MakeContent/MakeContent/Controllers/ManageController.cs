using MakeContentDomain.Models.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MakeContentUI.Controllers
{
    public class ManageController : Controller
    {
        private readonly UserManager<User> _userManager;
        public ManageController(UserManager<User> userManager)
        {
            this._userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        //public async Task<IActionResult> Pages() {
        //    var user = await _userManager.GetUserAsync(ClaimsPrincipal.Current);
        //    return View(user.Pages);
        //}
    }
}
