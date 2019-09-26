using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Application.Controllers
{
    /// <summary>
    /// Base of each controller in the application. It basically sets up the route and apply ApiController attribute. 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
        public ApiControllerBase() : base() { }
    }
}
