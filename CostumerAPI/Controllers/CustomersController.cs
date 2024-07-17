using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CostumerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CustomersController : ControllerBase
    {
        public IActionResult Get()
        {
            return Ok(new List<string> {
            "John", "Micheal", "Lisa", "Elizabeth", "Murray"
         });
        }
    }
}
