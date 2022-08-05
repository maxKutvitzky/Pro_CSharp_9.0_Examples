﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoLot.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new string[] { "value1", "value2" });
        }
        [HttpGet("one")]
        public IEnumerable<string> Get1()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet("two")]
        public ActionResult<IEnumerable<string>> Get2()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet("three")]
        public string[] Get3()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet("four")]
        public IActionResult Get4()
        {
            return new JsonResult(new string[] { "value1", "value2" });
        }
        [HttpGet("error")]
        public IActionResult Error()
        {
            return NotFound();
        }
    }
}
