using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaDeliveryAPI.Models;
using PizzaDeliveryAPI.Repository;

namespace PizzaDeliveryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private IRepository<Pizza> _rep;

        public PizzaController(IRepository<Pizza> repository)
        {
            _rep = repository;
        }

        // GET api/pizza
        [HttpGet]
        public IEnumerable<Pizza> Get()
        {
            return _rep.GetAll();
        }

        // GET api/pizza/5
        [HttpGet("{id}")]
        public Pizza Get(int id)
        {
            return _rep.Get(id);
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
            _rep.Delete(id);
            _rep.Save();
        }
    }
}
