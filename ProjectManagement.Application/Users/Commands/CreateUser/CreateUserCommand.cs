using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagement.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<bool>
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
