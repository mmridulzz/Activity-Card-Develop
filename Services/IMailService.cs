using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication9.Models;

namespace WebApplication9.Services
{
    public interface IMailService
    {
        
           Task SendEmailAsync(MailRequest mailRequest);
    }
}
