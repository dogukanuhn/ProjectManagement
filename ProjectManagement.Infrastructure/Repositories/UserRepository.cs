using MongoDB.Driver;
using ProjectManagement.Application.Common.Interfaces;
using ProjectManagement.Domain.Models;
using ProjectManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly IMongoDbContext<User> _context;
        private readonly IMongoCollection<User> _collection;
        public UserRepository(IMongoDbContext<User> context)
        {
            _context = context;
            _collection = _context.GetCollection();
        }

        public async Task<User> AddAsync(User entity,CancellationToken token)
        {
            var options = new InsertOneOptions { BypassDocumentValidation = false };
            await _collection.InsertOneAsync(entity, options,token);
            return entity;
        }

        public async Task<User> GetAsync(Expression<Func<User, bool>> predicate)
        {

            return await _collection.Find(predicate).FirstOrDefaultAsync();
        }
    }
}
