using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Entities
{
    public class Notification
    {
        [Key]
        public int NId { get; set; }
        public string Message { get; set; }
        public string Readstatus { get; set; }
        public int NUserId { get; set; }
        public User User { get; set; }
    }
}
