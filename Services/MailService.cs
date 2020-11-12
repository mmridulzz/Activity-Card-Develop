using MailKit.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using WebApplication9.Entities;
using WebApplication9.Helpers;
using WebApplication9.Models;

namespace WebApplication9.Services
{
    
    public class MailService : IMailService
    {
       
        private DataContext _context;
       
        public MailService(DataContext context)
        {
            _context = context;
        }
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            var user = await _context.Teacher.Where(s => s.TeacherUserRef == mailRequest.Id)
                          .FirstOrDefaultAsync();

            var smtpClient = new SmtpClient("smtp.ethereal.email")
            {
                Port = 587,
                Credentials = new NetworkCredential("jillian25@ethereal.email", "xE2Unny7PXWSC3quvR"),
                EnableSsl = true,
            };
            var body = user.Email+": username"+'\n';

            smtpClient.Send("shweta.vk91@gmail.com", "shweta.vk91@gmail.com", "subject", body);
            var user1 = await _context.Users.Where(s => s.Id == mailRequest.Id)
                          .FirstOrDefaultAsync();
            var teacher = _context.Users.Find(user1.Id);
            if (teacher == null)
                throw new AppException("User not found");
            teacher.Notification = "yes";
            _context.Users.Update(teacher);
            _context.SaveChanges();
           

        }
    }
}
