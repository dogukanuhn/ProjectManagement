using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagement.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }

    }
}
