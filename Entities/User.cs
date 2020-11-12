﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication9.Models;

namespace WebApplication9.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; }
        public string Notification { get; set; }
        public Teacher Teacher { get; set; }
        public Student Student { get; set; }
        public Admin Admin { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}
