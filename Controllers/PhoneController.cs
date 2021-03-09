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
    public class PhoneController : ControllerBase
    {
        private readonly Repository _context;

        public PhoneController(Repository context)
        {
            _context = context;
        }


        [HttpGet("{id}")]
        public IEnumerable<ViewPhone> GetPhoneList(int id)
        {
            var phone = _context.PhoneList(id);
            return (phone);
        }

        [HttpPost]
        public ActionResult Create(Phone phone)
        {
            _context.CreatePhone(phone);
            return Ok();
        }
        [HttpPost("{id}")]
        public ActionResult Edit(Phone phone)
        {
            _context.EditPhone(phone);
            return Ok();
        }

        [HttpDelete("{id}")]
        public void Del(int id)
        {
            _context.DelPhone(id);
        }
    }
}
