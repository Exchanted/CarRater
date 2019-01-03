using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRater.Models
{
    public class CommentsViewModel
    {
        public Posts posts { get; set; }
        public List<Comments> Comments { get; set; } 

        public int PostsID { get; set; }

        [Required]
        public String Comment { get; set; }
    }
}
