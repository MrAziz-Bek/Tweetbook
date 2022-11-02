using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Tweetbook.Controllers;

public class TestController : Controller
{
    [HttpGet("api/user")]
    public IActionResult Get()
    {
        return Ok(new { name = "Azizbek" });
    }
}