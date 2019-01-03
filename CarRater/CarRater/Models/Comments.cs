using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRater.Models
{
    public class Comments
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(250)]
        public String Comment { get; set; }

        public String UserId { get; set; }
        
        public virtual Posts MyPosts { get; set; }
    }
}
