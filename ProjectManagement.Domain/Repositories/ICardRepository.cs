using ProjectManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Domain.Repositories
{
    public interface ICardRepository
    {
        Task<Card> AddAsync(Card entity, CancellationToken token);
        IQueryable<Card> Get(Expression<Func<Card, bool>> predicate = null);
        Task<Card> UpdateAsync(string id, Card entity);


    }
}
