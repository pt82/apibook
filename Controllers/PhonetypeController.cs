using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApiBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApiBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhonetypeController : ControllerBase
    {
        private readonly Repository _context;

        public PhonetypeController(Repository context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Phonetype>>> GetType()
        {
            var type = _context.ListType();
             return  Ok(type);
        }

    }
}
