using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagement.Domain.Common
{
    public interface IEmailService
    {
        void Send(string from, string to, string subject, string html);
    }
}
