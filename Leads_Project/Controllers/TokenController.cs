using FG.Authentication.Interface;
using FG.Domain.DataEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leads_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IJTAuth auth;

        public TokenController(IJTAuth auth)
        {
            this.auth = auth;
        }
        [AllowAnonymous]
        // POST api/<MembersController>
        [HttpPost("authentication")]
        public IActionResult Authentication([FromBody] UserCredential userCredential)
        {
            var token = auth.Authentication(userCredential.UserName, userCredential.Password);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
    }
}
