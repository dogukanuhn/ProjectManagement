using MediatR;
using ProjectManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagement.Application.Cards.Queries.GetAllCards
{
    public class GetCardListQuery : IRequest<IEnumerable<Card>>
    {


        
    }
}
