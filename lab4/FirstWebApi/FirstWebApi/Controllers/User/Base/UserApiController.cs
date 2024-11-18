using FirstWebApi.Attributes;
using FirstWebApi.Bll.Enums;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApi.Controllers.User.Base
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("/user/api/[controller]")]
    [CustomAuthorize(UserRole.User)]
    public class UserApiController : ControllerBase
    {
    }
}
