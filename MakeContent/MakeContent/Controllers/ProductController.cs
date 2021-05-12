using MakeContentBLL.Services;
using MakeContentDomain.Models;
using MakeContentDomain.Models.IdentityModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeContentUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AuthorPageService _service;
        private readonly UserManager<User> _userManager;
        public ProductController(UserManager<User> userManager, AuthorPageService service) {
            this._service = service;
            this._userManager = userManager;
        }
        public async Task<string> GetPagesAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var pages = await _service.LoadPages(user.Id);
            var res = JsonConvert.SerializeObject(pages, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            return res;
        }
    }
}
