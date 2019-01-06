using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

/**
 * Post model containing: postID, title, link to imgur post which links to a UserID when posted
 **/
namespace CarRater.Models
{
    public class Posts
    {
        // Post ID
        public int Id { get; set; }
        
        // Post Title
        [Required]
        [StringLength(50)]
        public String Title { get; set; }
        
        //Post Link
        //Regex for Imgur links only ending in .jpg or .png types
        [Required]
        [StringLength(250)]
        [RegularExpression(@"(?:https?:\/\/)?(?:i\.)?imgur\.com\/(.+(?=[sbtmlh]\..{3,4})|.+(?=\..{3,4})|.+?(?:(?=\s)|$))(.jpg|.png|.gif)", ErrorMessage = "Link must be from Imgur and of type '.jpg' or '.png'")]
        public String Link { get; set; }

        // UserID of who created the Post
        public String UserId { get; set; }
    }
}
