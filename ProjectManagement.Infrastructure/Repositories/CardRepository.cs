using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProjectManagement.Domain.Models;
using ProjectManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Infrastructure.Repositories
{
    public class CardRepository : ICardRepository
    {
        protected readonly IMongoCollection<Card> Collection;
        private readonly MongoDbSettings settings;
        public CardRepository(IOptions<MongoDbSettings> options)
        {
            this.settings = options.Value;
            var client = new MongoClient(this.settings.ConnectionString);
            var db = client.GetDatabase(this.settings.Database);
            this.Collection = db.GetCollection<Card>(typeof(Card).Name.ToLowerInvariant());
        }

        public async Task<Card> AddAsync(Card entity, CancellationToken token)
        {
            var options = new InsertOneOptions { BypassDocumentValidation = false };
            await Collection.InsertOneAsync(entity, options,token);
            return entity;
        }
    }
}
