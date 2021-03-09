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
    public class ContactsController : ControllerBase
    {
        private readonly Repository _context;

        public ContactsController(Repository context)
        {
            _context = context;
        }

        // GET: api/Contacts/5
        [HttpGet("{id}")]

        public async Task<ActionResult<Contact>> ShowContact(int id)
        {
          var contact = _context.ShowContact(id);
          return Ok(contact);
        }

        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            _context.CreateContact(contact);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<Contact>> Edit(Contact contact)
        {
            _context.EditContact(contact);
            return Ok(contact);
 
        }

        // DELETE: api/Contacts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Contact>> Delete(int id)
        {
            _context.DeleteContact(id);
            return Ok();

        }


 

       
    }
}
