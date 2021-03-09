using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApiBook.Models;

namespace MyApiBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SexesController : ControllerBase
    {
        private readonly Repository _context;

        public SexesController(Repository context)
        {
            _context = context;
        }

        // GET: api/Sexes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sex>>> GetSexes()
        {
            var sex = _context.SexList();
            return Ok(sex);
        }

  

 

    
    }
}
