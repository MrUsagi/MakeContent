using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeContentDomain.Models.IdentityModels
{
    public class User : IdentityUser<Guid>
    {
        public string ImagePath { get; set; } = "https://st.depositphotos.com/1008939/1880/i/600/depositphotos_18807295-stock-photo-portrait-of-handsome-man.jpg";
        //public ICollection<AuthorPage> Pages { get; set; }
    }
}
