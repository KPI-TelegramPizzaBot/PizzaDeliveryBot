﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PizzaDeliveryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController :ControllerBase
    {
        // GET api/pizza
        [HttpGet]
        public ActionResult<List<string>> Get()
        {
            List<string> res = new List<string>();
            res.Add("Pizza1");
            res.Add("Pizza2");
            return res;
        }

        // GET api/pizza/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "PizzaDelivery";
        }

        // POST api/pizza
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/pizza/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/pizza/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
