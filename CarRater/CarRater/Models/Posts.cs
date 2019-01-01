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

        [StringLength(50)]
        [Required]
        public String Title { get; set; }

        [StringLength(250)]
        [Required]
        public String Link { get; set; }

        public String UserId { get; set; }
    }
}
