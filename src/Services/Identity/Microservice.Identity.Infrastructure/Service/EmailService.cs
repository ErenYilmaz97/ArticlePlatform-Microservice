using Microservice.Identity.Application.Service;
using Microservice.Identity.Domain.Model;
using Microservice.Identity.Domain.Model.Email;
using Microservices.Core.Utilities.Result.Business;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Infrastructure.Service
{
    public class EmailService : IEmailService
    {
        private SmtpClient _client;
        private EmailOptions _emailOptions;


        public EmailService(IOptions<EmailOptions> emailOptions)
        {
            _emailOptions = emailOptions.Value;

            _client = new SmtpClient()
            {
                UseDefaultCredentials = _emailOptions.UseDefaultCredentials,
                Credentials = new NetworkCredential(_emailOptions.Email, _emailOptions.Password),
                Port = _emailOptions.Port,
                Host = _emailOptions.Host,
                EnableSsl = _emailOptions.EnableSSL
            };
        }

        public async Task<IBusinessResult> SendConfirmAccountEMail(SendConfirmAccountRequest request)
        {
            var accountConfirmationLink = $"{_emailOptions.ApplicationUrl}/api/User/ConfirmEmail";

            MailMessage mail = new MailMessage()
            {
                From = new MailAddress(_emailOptions.Email),
                Subject = "Hesap Onayı",
                Body =
                        $"<h4>Hesabınız Başarıyla Oluşturuldu. Giriş Yapabilmek İçin Mail Adresinizi Onaylamanız Gerekmektedir.</h4>" +
                        $"<h5>Mail Adresinizi Onaylamak İçin Aşağıdaki Linke Tıklayabilirsiniz.</h5>" +
                        $"{accountConfirmationLink}",

                IsBodyHtml = true
            };

            mail.To.Add(request.Email);


            try
            {
                _client.SendAsync(mail, null);
                return new SuccessBusinessResult("Email Sent Successfully.", string.Empty);
            }
            catch (Exception ex)
            {
                return new FailBusinessResult(ex.Message, string.Empty);
            }


        }


        public async Task<IBusinessResult> SendResetPasswordEmail(SendResetPasswordRequest request)
        {
            string resetPasswordLink = $"{_emailOptions.Email}/api/User/ResetPassword";

            MailMessage mail = new MailMessage()
            {
                From = new MailAddress(_emailOptions.Email),
                Subject = "Şifre Sıfırlama",
                Body = $"<h3>Şifrenizi Aşağıdaki Linkten Sıfırlayabilirsiniz.</h3> {resetPasswordLink}",
                IsBodyHtml = true
            };

            mail.To.Add(request.Email);


            try
            {
                _client.SendAsync(mail, null);
                return new SuccessBusinessResult("Email Sent Successfully.", string.Empty);
            }
            catch (Exception ex)
            {
                return new FailBusinessResult(ex.Message, string.Empty);
            }

        }
    }
}
