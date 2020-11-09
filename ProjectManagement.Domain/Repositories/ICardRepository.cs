using ProjectManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Domain.Repositories
{
    public interface ICardRepository
    {
        Task<Card> AddAsync(Card entity, CancellationToken token);

    }
}
