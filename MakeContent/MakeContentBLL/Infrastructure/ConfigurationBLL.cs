using MakeContentCore.Context;
using MakeContentDomain.Models.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeContentBLL.Infrastructure
{
    public static class ConfigurationBLL
    {
        public static void Configuration(IServiceCollection services, string connString)
        {
            services.AddDbContext<CreatorsContext>(x=>x.UseSqlServer(connString));
            services.AddIdentity<User, Role>(x=>x.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<CreatorsContext>().AddDefaultTokenProviders().AddToke;
        }
    }
}
