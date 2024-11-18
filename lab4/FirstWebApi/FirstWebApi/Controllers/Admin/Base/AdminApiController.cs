using FirstWebApi.Attributes;
using FirstWebApi.Bll.Enums;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApi.Controllers.Admin.Base
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("/admin/api/[controller]")]
    [CustomAuthorize(UserRole.Admin)]
    public class AdminApiController : ControllerBase
    {
    }
}
