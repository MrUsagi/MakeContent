using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeContentDomain.Models
{
    public class Category
    {
        public Category()
        {
            SubCategories = new List<Category>();
            Pages = new List<AuthorPage>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Category> SubCategories { get; set; }
        public ICollection<AuthorPage> Pages { get; set; }
    }
}
