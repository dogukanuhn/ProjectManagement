using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagement.Application.Common.Interfaces
{
    public interface IMongoDbSettings
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }
}
