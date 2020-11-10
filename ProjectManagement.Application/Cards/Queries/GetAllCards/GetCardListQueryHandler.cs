using MediatR;
using ProjectManagement.Domain.Models;
using ProjectManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Cards.Queries.GetAllCards
{
    public class GetCardListQueryHandler : IRequestHandler<GetCardListQuery,IEnumerable<Card>>
    {
        private readonly ICardRepository _cardRepository;
        public GetCardListQueryHandler(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task<IEnumerable<Card>> Handle(GetCardListQuery request, CancellationToken cancellationToken)
        {
            var list =  _cardRepository.Get();
            return list;
        }
    }
}
