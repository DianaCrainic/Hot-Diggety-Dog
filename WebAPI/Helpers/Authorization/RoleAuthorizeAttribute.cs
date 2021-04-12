using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using WebAPI.Entities;
using WebAPI.Resources;

namespace WebAPI.Helpers.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class RoleAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly Role _role;

        public RoleAuthorizeAttribute(Role role)
        {
            _role = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            User user = (User)context.HttpContext.Items[Constants.UserItem];

            if (user == null || user.Role != _role)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
