using Microsoft.AspNetCore.Mvc;

namespace GraphQL.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class RootController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        public RootController()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("", Name = nameof(Get))]
        public IActionResult Get()
        {
            return Ok("Test");
        }
    }
}