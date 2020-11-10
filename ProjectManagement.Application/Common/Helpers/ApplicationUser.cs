using Microsoft.AspNetCore.Http;
using ProjectManagement.Domain.Common;
using System.Security.Claims;

namespace ProjectManagement.Application.Common.Helpers
{
    public class ApplicationUser: IApplicationUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApplicationUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            Email = GetUserMail();
        }


        public string Email { get; set; }

        public string GetUserMail()
        {
            return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
        }


    }
}
