using ProjectManagement.Application.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagement.Application.Common.Interfaces
{
    public interface IEmailService
    {
        void Send(EmailMessage emailMessage);
    }
}
