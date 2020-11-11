using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagement.Application.Common.Interfaces
{
    public interface IEmailConfig
    {
        string SmtpServer { get; }
        int SmtpPort { get; }
        string SmtpUsername { get; set; }
        string SmtpPassword { get; set; }

    }
}
