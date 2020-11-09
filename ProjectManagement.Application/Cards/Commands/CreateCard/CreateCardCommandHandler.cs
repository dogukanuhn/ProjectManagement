using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ProjectManagement.Domain.Models;
using ProjectManagement.Application.Common;


namespace ProjectManagement.Application.Cards.Commands.CreateCard
{
    class CreateCardCommandHandler : IRequestHandler<CreateCardCommand, string>
    {
        private readonly IRepository<Card> _repository;
        public CreateCardCommandHandler(IRepository<Card> repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(CreateCardCommand request, CancellationToken cancellationToken)
        {
            var entity = new Card
            {
                Content = request.Content,
                CreatedBy = request.CreatedBy,
                IsDone = request.IsDone,
                Title = request.Title,
                Created=DateTime.Now
            };

            await _repository.AddAsync(entity, cancellationToken);


            return entity.Id;

        }
    }
}
