using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

/**
 * ViewSpecific Model of what a comment should be used as a middle between Posts and Comments
 **/
namespace CarRater.Models
{
    public class CommentsViewModel
    {
        // Post
        public Posts posts { get; set; }

        // List of comments related to the post
        public List<Comments> Comments { get; set; } 

        //PostID relating to comments
        public int PostsID { get; set; }

        //Comment given by user, required so can't submit a blank comment
        [Required]
        [StringLength(250)]
        public String Comment { get; set; }
    }
}
