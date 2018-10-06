using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Services.EmailService
{
    public interface IEmailService
    {
        MimeMessage CreateEmail();

        string GetEmailAddressSender();

        string GetEmailAddressReceiver();

        Task SendEmail(MimeMessage message);
    }
}
