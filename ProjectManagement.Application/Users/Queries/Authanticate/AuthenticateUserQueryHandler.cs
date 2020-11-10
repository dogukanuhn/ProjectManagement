using MediatR;
using ProjectManagement.Domain.Common;
using ProjectManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Users.Queries
{
    public class AuthenticateUserQueryHandler : IRequestHandler<AuthenticateUserQuery, (string email, string token)?>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtHandler _jwtHandler;

        public AuthenticateUserQueryHandler(IUserRepository userRepository, IJwtHandler jwtHandler)
        {
            _userRepository = userRepository;
            _jwtHandler = jwtHandler;
        }

        public async Task<(string email, string token)?> Handle(AuthenticateUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(x => x.Email == request.Email && x.Password == request.Password);

            if (user == null)
                return null;

            return  _jwtHandler.Authenticate(user);
        }
    }
}
