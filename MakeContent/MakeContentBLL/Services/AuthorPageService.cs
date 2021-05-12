using MakeContentCore.Context;
using MakeContentDomain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeContentBLL.Services
{
    public class AuthorPageService
    {
        private readonly CreatorsContext _context;
        public AuthorPageService(CreatorsContext context)
        {
            this._context = context;
        }

        public async Task CreateAuthorPageAsync(Guid userId, AuthorPage page)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if(user != null)
            {
                user.Pages.Add(page);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<AuthorPage>> LoadPages(Guid userId)
        {
            var user = await _context.Users.Include(x => x.Pages).FirstOrDefaultAsync(x => x.Id == userId);
            return user.Pages;
        }

        public async Task CreateTierAsync(Guid pageId, Tier tier)
        {
            //var page = await _context.Authors.Include(x=>x.Tiers).FirstOrDefaultAsync(x=>x.Id == pageId);
            //if (page != null)
            //{
            //    page.Tiers.Add(tier);
            //    await _context.SaveChangesAsync();
            //}
        }
    }
}
