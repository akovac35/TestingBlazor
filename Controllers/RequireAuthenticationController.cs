using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestingBlazor.Controllers
{
    [Route("api/requireauthentication")]
    [ApiController]
    [Authorize]
    public class RequireAuthenticationController : ControllerBase
    {
        public RequireAuthenticationController(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessorInstance = httpContextAccessor;
        }

        public IHttpContextAccessor HttpContextAccessorInstance { get; }

        [HttpGet]
        public virtual IActionResult SimpleTask()
        {
            var user = HttpContextAccessorInstance.HttpContext.User;

            return StatusCode(200, $"Authenticated as: {user?.Identity?.Name}");
        }
    }
}
