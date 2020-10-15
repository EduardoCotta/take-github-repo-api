using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TakeGithubAPI.Controllers
{
    [Route("")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public object GetStatus()
        {
            var responseObject = new
            {
                Status = "Funcionando",
                CurrentDate = DateTime.Now
            };

            return responseObject;
        }
    }
}
