using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ProjectManagement.Domain.Models;
using ProjectManagement.Application.Common;
using ProjectManagement.Domain.Repositories;
using System.Security.Claims;
using ProjectManagement.Domain.Common;

namespace ProjectManagement.Application.Cards.Commands.CreateCard
{
    class CreateCardCommandHandler : IRequestHandler<CreateCardCommand, string>
    {
        private readonly ICardRepository _repository;
        private readonly IApplicationUser _applicationUser;

        public CreateCardCommandHandler(ICardRepository repository, IApplicationUser applicationUser)
        {
            _repository = repository;
            _applicationUser = applicationUser;
        }

        public async Task<string> Handle(CreateCardCommand request, CancellationToken cancellationToken)
        {
            var userMail = _applicationUser.Email;
            var entity = new Card
            {
                Content = request.Content,
                CreatedBy = userMail,
                IsDone = request.IsDone,
                Title = request.Title,
                Created = DateTime.Now,
                ExpireTime = request.ExpireTime,
                NotificationEmail = string.IsNullOrEmpty(request.NotificationEmail) ? userMail : request.NotificationEmail
            };

            await _repository.AddAsync(entity, cancellationToken);


            return entity.Id;

        }
    }
}
