using MakeContentDomain.Models.Enums;
using MakeContentDomain.Models.IdentityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeContentDomain.Models
{
    public class AuthorPage
    {
        public AuthorPage()
        {
            Posts = new List<Post>();
            Followers = new List<Follower>();
            Subscriptions = new List<Subscription>();
            Tiers = new List<Tier>();
            Categories = new List<Category>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string ProfileImageURL { get; set; }
        public string CoverImageURL { get; set; }
        public bool IsNSFW { get; set; }
        public PricingType Pricing { get; set; }
        public string PageCustomURL { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Post> Posts { get; set; }//Посты
        public ICollection<Follower> Followers { get; set; }//Бесплатная подписка на рассылку
        public ICollection<Subscription> Subscriptions { get; set; }//Платные подписки
        public ICollection<Tier> Tiers { get; set; }//Уровни подписки

        public Guid OwnerId { get; set; }
        public User Owner { get; set; }
        public ICollection<Category> Categories { get; set; }

    }
}
