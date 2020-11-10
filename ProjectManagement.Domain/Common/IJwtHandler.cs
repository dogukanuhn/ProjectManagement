using ProjectManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Domain.Common
{
    public interface IJwtHandler
    {
        (string email, string token)? Authenticate(User user);
    }
}
