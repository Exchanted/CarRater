using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

/**
 * Comment model containing: CommentID, Comment, UserID, Virtual MyPosts to link comments to posts in DB
 **/
namespace CarRater.Models
{
    public class Comments
    {
        //ID of comment
        public int Id { get; set; }
        
        //Comment given by user
        [Required]
        [StringLength(250)]
        public String Comment { get; set; }

        //ID of Commenter
        public String UserId { get; set; }
        
        //Used to link Posts to Comments 
        public virtual Posts MyPosts { get; set; }
    }
}
