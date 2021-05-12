using MakeContentDomain.Models;
using MakeContentDomain.Models.IdentityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
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
            //var databaseCreator = (Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator);
            //databaseCreator.CreateTables();
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().HasKey(x => x.Id);
            builder.Entity<User>().HasMany(x => x.Pages).WithOne(x=>x.Owner).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<AuthorPage>().HasMany(x => x.Tiers).WithOne(x=>x.Author).OnDelete(DeleteBehavior.NoAction);
        }
        //public DbSet<AuthorPage> Authors { get; set; }
    }
}
