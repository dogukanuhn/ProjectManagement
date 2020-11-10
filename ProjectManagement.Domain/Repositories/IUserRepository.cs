using ProjectManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Domain.Repositories
{
    public interface IUserRepository
    {

        Task<User> GetAsync(Expression<Func<User, bool>> predicate);
        Task<User> AddAsync(User entity, CancellationToken token);

    }
}
