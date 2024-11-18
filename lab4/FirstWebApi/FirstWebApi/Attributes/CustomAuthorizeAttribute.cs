using FirstWebApi.Bll.Enums;
using Microsoft.AspNetCore.Authorization;

namespace FirstWebApi.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public CustomAuthorizeAttribute(string policy) : base(policy)
        {
        }

        public CustomAuthorizeAttribute(UserRole role) : base()
        {
            base.Roles = role.ToString();
        }
    }
}
