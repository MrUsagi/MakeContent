using MakeContent.Models;
using MakeContentBLL.Services;
using MakeContentBLL.Services.Interfaces;
using MakeContentDomain.Models;
using MakeContentDomain.Models.IdentityModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MakeContent.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailSender _emailSender;
        private readonly UserManager<User> _userManager;
        private readonly AuthorPageService _service;
        public HomeController(ILogger<HomeController> logger, IEmailSender emailSender, UserManager<User> userManager, AuthorPageService service)
        {
            _logger = logger;
            _emailSender = emailSender;
            _userManager = userManager;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
               // await _service.CreateAuthorPageAsync(user.Id, new AuthorPage()
               // {
               //     Name = "Koningsten",
               //     IsShowInfo = false,
               //     About = "Hello my name Koning, I'm creating music notes, patron on me and know how it.",
               //     IsActive = true,
               //     ProfileImageURL = "https://i.stack.imgur.com/l60Hf.png",
               //     CoverImageURL = "https://i.pinimg.com/originals/3e/2c/25/3e2c2526c2fb2baf0cf16cfe137924b5.jpg"
               // });
            }
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
