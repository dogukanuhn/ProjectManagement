using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProjectManagement.Application.Common.Interfaces;
using ProjectManagement.Domain.Models;
using ProjectManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Infrastructure.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly IMongoDbContext<Card> _context;
        private readonly IMongoCollection<Card> _collection;
        public CardRepository(IMongoDbContext<Card> context)
        {
            _context = context;
            _collection = _context.GetCollection();
        }

        public async Task<Card> AddAsync(Card entity, CancellationToken token)
        {
            var options = new InsertOneOptions { BypassDocumentValidation = false };
            await _collection.InsertOneAsync(entity, options,token);
            return entity;
        }

        public IQueryable<Card> Get(Expression<Func<Card, bool>> predicate = null)
        {
            return predicate == null
                ? _collection.AsQueryable()
                : _collection.AsQueryable().Where(predicate);
        }

        public  async Task<Card> UpdateAsync(string id, Card entity)
        {
            return await _collection.FindOneAndReplaceAsync(x => x.Id == id, entity);
        }
    }
}
