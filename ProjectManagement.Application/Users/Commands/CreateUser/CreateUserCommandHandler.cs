using MediatR;
using ProjectManagement.Domain.Models;
using ProjectManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User {
                Email = request.Email,
                FirstName = request.FirstName,
                Password = request.Password,
                Surname = request.Surname
            };

            var result = await _userRepository.AddAsync(user,cancellationToken);
            if (result == null)
                return false;

            return true;
        }
    }
}
