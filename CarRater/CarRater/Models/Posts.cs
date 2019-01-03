using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRater.Models
{
    public class Posts
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public String Title { get; set; }
        
        //Regex for Imgur links only ending in .jpg or .png types
        [Required]
        [StringLength(250)]
        [RegularExpression(@"(?:https?:\/\/)?(?:i\.)?imgur\.com\/(.+(?=[sbtmlh]\..{3,4})|.+(?=\..{3,4})|.+?(?:(?=\s)|$))(.jpg|.png|.gif)", ErrorMessage = "Link must be from Imgur and of type '.jpg' or '.png'")]
        public String Link { get; set; }

        public String UserId { get; set; }
    }
}
