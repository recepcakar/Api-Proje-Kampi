using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Dtos.ContactDtos;
using ApiProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ApiContext _context;

        public ContactController(ApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _context.Contacts.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            Contact contact = new Contact();
            contact.ContactEmail = createContactDto.ContactEmail;
            contact.ContactPhone = createContactDto.ContactPhone;
            contact.Adress = createContactDto.Adress;
            contact.MapLocation = createContactDto.MapLocation;
            contact.OpeningHours = createContactDto.OpeningHours;
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Ok("Added is complete");
        }
        [HttpDelete]
        public IActionResult DeleteContact(int id) 
        {
          var values=  _context.Contacts.Find(id);
          _context.Remove(values);
          _context.SaveChanges( ) ;
          return Ok("Object Deleted");
        }
        [HttpGet("GetContact")]
        public IActionResult GetContact(int id) 
        { 
            var values=_context.Contacts.Find(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            Contact contact = new Contact();
            contact.ContactEmail = updateContactDto.ContactEmail;
            contact.ContactPhone = updateContactDto.ContactPhone;
            contact.Adress = updateContactDto.Adress;
            contact.MapLocation = updateContactDto.MapLocation;
            contact.OpeningHours = updateContactDto.OpeningHours;
            contact.ContactId = updateContactDto.ContactId; 
            _context.Contacts.Update(contact);
            _context.SaveChanges();
            return Ok("complied");

        }
    }
}
