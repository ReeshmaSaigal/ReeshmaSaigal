using Domain.Modules.Auth.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helper
{
    public class EmailHelper : IEmailHelper
    {
        private readonly IConfiguration _config;

        public EmailHelper(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendAsync(string to, string subject, string body)
        {
            try
            {
                var host = _config["Email:SmtpHost"];
                var portString = _config["Email:SmtpPort"];
                var user = _config["Email:SmtpUser"];
                var pass = _config["Email:SmtpPass"];
                var enableSslString = _config["Email:EnableSSL"];

                if (string.IsNullOrEmpty(host) || string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
                    throw new Exception("Email configuration is missing in appsettings.json.");

                int port = 587; // default
                if (!string.IsNullOrEmpty(portString))
                    int.TryParse(portString, out port);

                bool enableSsl = true;
                if (!string.IsNullOrEmpty(enableSslString))
                    bool.TryParse(enableSslString, out enableSsl);

                using var client = new SmtpClient(host, port)
                {
                    Credentials = new NetworkCredential(user, pass),
                    EnableSsl = enableSsl,
                    UseDefaultCredentials = false
                };

                using var message = new MailMessage(user, to, subject, body)
                {
                    IsBodyHtml = true
                };

                await client.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                throw new Exception($"Email send failed: {ex.Message}", ex);
            }
        }
    }

    }