using JogoJustoDotNet.Service;
using Microsoft.AspNetCore.Authorization;

namespace JogoJustoDotNet.Auth
{
    public class RoleAuthorizationHandler : AuthorizationHandler<RoleRequeriment>
    {
        private readonly ITokenService _tokenService;

        public RoleAuthorizationHandler(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequeriment requirement)
        {
            var httpContext = (context.Resource as Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext)?.HttpContext;
            if (httpContext == null)
                return Task.CompletedTask;

            var token = httpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (string.IsNullOrEmpty(token))
                return Task.CompletedTask;

            var userRole = _tokenService.GetRoleFromToken(token);
            if (userRole == null)
                return Task.CompletedTask;

            if (userRole == requirement.Role)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
