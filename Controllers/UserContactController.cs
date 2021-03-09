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
    public class UserContactController : ControllerBase
    {
       // ContactRepository repo = new ContactRepository();

       // public ActionResult GetContacts(int id)
      //  {
          //  Contact contact = repo.Get(id);
         //   if (repo.Get(id) != null)
          //      return repo.Get(id);
          //  return null;
     //   }

        private readonly Repository _context;

        public UserContactController(Repository context)
        {
            _context = context;
        }

      //  [HttpGet("{id}")]
      //  public IEnumerable<Contact> GetContact(int id)
       // {
       //     if (_context.Get(id) != null)
       //     { 
       //         return _context.Get(id);
       //         }
       //     return null;
            // var contact = await _context.Contacts.FindAsync(id);
           // var contact = (from i in _context.Contacts where i.UserId == id 
          //                 orderby i.Id descending
          //                 select i);

          //  return contact.ToList();
       // }


        [HttpGet("{id}")]
        public IEnumerable<VuewContact> ViewContact(int id)
        {
            if (_context.ViewContact(id) != null)
            {
                return _context.ViewContact(id);
            }
            return null;
            // var contact = await _context.Contacts.FindAsync(id);
            // var contact = (from i in _context.Contacts where i.UserId == id 
            //                 orderby i.Id descending
            //                 select i);

            //  return contact.ToList();
        }
    }
}
