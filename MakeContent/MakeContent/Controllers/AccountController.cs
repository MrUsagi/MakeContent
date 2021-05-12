using MakeContentBLL.Services;
using MakeContentBLL.Services.Interfaces;
using MakeContentDomain.Models.IdentityModels;
using MakeContentUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeContentUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IEmailSender _emailSender;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager, RoleManager<Role> roleManager, IEmailSender emailSender)
        {
            this._signInManager = signInManager;
            this._roleManager = roleManager;
            this._userManager = userManager;
            this._emailSender = emailSender;
        }

        [HttpGet]
        public async Task<IActionResult> Register(string returnUrl = "") => View();

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = "")
        {
            if (!TryValidateModel(model)) return StatusCode(500);

            var user = new User() { Email = model.Email, UserName = model.Login };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded) return StatusCode(500);

            if (await _roleManager.FindByNameAsync("user") == null)
            {
                var role = await _roleManager.CreateAsync(new Role() { Name = "user" });
                if (role.Succeeded)
                    await _userManager.AddToRoleAsync(user, "user");
            }
            else await _userManager.AddToRoleAsync(user, "user");

            //await _signInManager.SignInAsync(user, false);

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var link = Url.Action("ConfirmEmail", "Account",
                new { guid = token, userEmail = user.Email }, Request.Scheme, Request.Host.Value);
            await _emailSender.SendEmailAsync(user.Email, "Email Confirmation", link);

            return Redirect("/home/index");

        }

        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl = "") => View();



        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = "")
        {
            if (!TryValidateModel(model)) return StatusCode(500);

            var result = await _signInManager.PasswordSignInAsync(model.Login, model.Password, model.RememberMe, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return StatusCode(500);

        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Logout(string returnUrl = "")
        {
            await _signInManager.SignOutAsync();
            if (returnUrl == "/")
                return RedirectToAction("Index", "Home");
            else if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            else
                return StatusCode(404);
        }

        [HttpGet]
        public IActionResult ResetPasswordEmail() => View();

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ResetPassword(string userEmail)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var link = Url.Action("ChangePassword", "Account", new { guid = token, userEmail = user.Email }, Request.Scheme, Request.Host.Value);
            await _emailSender.SendEmailAsync(userEmail, "Password reset", link);
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public async Task<IActionResult> ChangePasswordAsync(string userEmail, string guid)
        {
            return View("ResetPassword", new ResetPasswordViewModel() { Email = userEmail, Guid = guid });
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ConfirmResetPassword(ResetPasswordViewModel model)
        {
            if (!TryValidateModel(model)) return View();

            var user = await _userManager.FindByEmailAsync(model.Email);
            var res = await _userManager.ResetPasswordAsync(user, model.Guid, model.Password);
            if (res.Succeeded)
                return RedirectToAction("Index", "Home");
            return StatusCode(404);
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmailAsync(string guid, string userEmail)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            var res = await _userManager.ConfirmEmailAsync(user, guid);
            if (res.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        
    }
}
