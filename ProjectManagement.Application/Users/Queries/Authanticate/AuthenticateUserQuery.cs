using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagement.Application.Users.Queries
{
    public class AuthenticateUserQuery : IRequest<(string email, string token)?>
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
