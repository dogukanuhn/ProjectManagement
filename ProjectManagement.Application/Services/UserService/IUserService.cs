using ProjectManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Services.UserService
{
    public interface IUserService
    {
        Task<Card> AddAsync(Card entity, CancellationToken cancellationToken);
    }
}
