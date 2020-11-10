using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagement.Application.Common.Interfaces
{
    public interface IMongoDbContext<T>
    {
        IMongoCollection<T> GetCollection();
    }
}
