using ProjectManagement.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagement.Application.Model
{
    public class EmailConfig : IEmailConfig
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }

    }
}
