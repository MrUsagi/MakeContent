using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeContentDomain.Models
{
    public class Post
    {
        public Post()
        {
            Comments = new List<Comment>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string Tag { get; set; }
        public DateTime PostDate { get; set; }
        public int Rating { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public Guid AuthorId { get; set; }
        public AuthorPage Author { get; set; }
        public Guid? TierId { get; set; }
        public Tier Tier { get; set; }
    }
}
