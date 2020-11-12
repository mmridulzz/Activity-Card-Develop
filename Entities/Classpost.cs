using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Entities
{
    public class Classpost
    {
        [Required]
        public int yearId { get; set; }
        [Required]
        public string classname { get; set; }
        [Required]
        public int[] TId { get; set; }
    }
}
