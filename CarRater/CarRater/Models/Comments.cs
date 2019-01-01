using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRater.Models
{
    public class Comments
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public String Comment { get; set; }
        
        public String UserId { get; set; }

        public virtual Posts MyPosts { get; set; }
    }
}
