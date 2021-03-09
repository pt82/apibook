using Microsoft.AspNetCore.Mvc;
using MyApiBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyApiBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewLogController : ControllerBase
    {
        private readonly Repository _context;

        public ViewLogController(Repository context)
        {
            _context = context;
        }
        // GET: api/<ViewLogController>
        [HttpPost]
       // public IEnumerable<ViewLog> Get()
        public List<ViewLog> Get(GetLog getLog)
        {
            
                return _context.LogList(getLog);
            
            
        }

        // GET api/<ViewLogController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ViewLogController>
      

        // PUT api/<ViewLogController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ViewLogController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
