using MakeContentDomain.Models.IdentityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeContentCore.Context
{
    public class CreatorsContext:IdentityDbContext<User,Role,Guid>
    {
        public CreatorsContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
