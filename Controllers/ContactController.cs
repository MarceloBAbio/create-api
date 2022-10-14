using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using create_api.Entities;
using create_api.Context;

namespace create_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly JournalContext _context;
        public ContactController(JournalContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            _context.Add(contact);
            _context.SaveChanges();
            return Ok(contact);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var contact = _context.Contacts.Find(id);

            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }
        [HttpGet("GetByName")]
        public IActionResult GetByName(string name)
        {
            var contacts = _context.Contacts.Where(x => x.Name.Contains(name));
            return Ok(contacts);
        }

        [HttpPut("{id")]
        public IActionResult Update(int id, Contact contact)
        {
            var contactBank = _context.Contacts.Find(id);
            if (contactBank == null)
            {
                return NotFound();
            }
            contactBank.Name = contact.Name;
            contactBank.Telephone = contact.Telephone;
            contactBank.Active = contact.Active;

            _context.Contacts.Update(contactBank);
            _context.SaveChanges();
            return Ok(contactBank);
        }

        [HttpDelete("{id")]
        public IActionResult Delete(int id)
        {
            var contactBank = _context.Contacts.Find(id);
            if (contactBank == null)
            {
                return NotFound();
            }
            _context.Contacts.Remove(contactBank);
            _context.SaveChanges();
            return NoContent();
        }
    }
}