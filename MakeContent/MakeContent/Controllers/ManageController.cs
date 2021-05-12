using MakeContentBLL.Services;
using MakeContentDomain.Models;
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
        private readonly AuthorPageService _service;
        public ManageController(UserManager<User> userManager, AuthorPageService service)
        {
            this._userManager = userManager;
            this._service = service;
        }
        public async Task<IActionResult> Index()
        {

            return View("Pages");
        }

        public async Task<IActionResult> Members()
        {
            return View();
        }

        public async Task<IActionResult> OpenPage(Guid pageId)
        {
            var user = await _userManager.GetUserAsync(User);
            var pages = await _service.LoadPages(user.Id);
            var page = pages.FirstOrDefault(x => x.Id == pageId);
            if(page != null) return View("Page", page);
            return StatusCode(404);
        }

        public async Task<IActionResult> PageCardPartial(AuthorPage page)
        {
            return PartialView(page);
        }
        //public async Task<IActionResult> Pages() {
        //    var user = await _userManager.GetUserAsync(ClaimsPrincipal.Current);
        //    return View(user.Pages);
        //}
    }
}
