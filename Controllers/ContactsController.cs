using CRUD_WithAPI.Data;
using CRUD_WithAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_WithAPI.Controllers
{
    [ApiController]// MVCController مش ApiController بقله ان دا 
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly APIDbContext dbContext;

        // incect DbContext
        public ContactsController(APIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        [Route("api/GetALl")]
        public IActionResult GetContact()
        {
            var contact = dbContext.Contacts.ToList();
            return Ok(contact);
        }

        [HttpPost]
        [Route("id:int")]
        public async Task<IActionResult> GetContactById(int id)
        {
            
            var contact = dbContext.Contacts.FindAsync(id);
            if (contact!=null)
            {
                return Ok(contact);
            }
            return BadRequest("Not Found");
        }
        [HttpPost]
        [Route("api/Add")]
        public async Task<IActionResult> AddContact(AddContact addcontact)
        {
            var newcontact = new Contact()
            {
                FullName = addcontact.FullName,
                Address = addcontact.Address,
                Email = addcontact.Email,
                Phone = addcontact.Phone,
            };
            await dbContext.Contacts.AddAsync(newcontact);
            await dbContext.SaveChangesAsync();
            return Ok(newcontact);
        }



        [HttpPut]
        [Route("id:int")]
        public async Task<IActionResult> UpdateContactAsync (int id , UpdateContact updateContact)
        {
            var oldcontact = await dbContext.Contacts.FindAsync(id);
            if(oldcontact!=null)
            {
                oldcontact.FullName = updateContact.FullName;
                oldcontact.Address = updateContact.Address;
                oldcontact.Email = updateContact.Email;
                oldcontact.Phone = updateContact.Phone;
                dbContext.SaveChangesAsync();
                return Ok(oldcontact);
            }
            return NotFound();
        }


        [HttpDelete]
        [Route("id:int")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contact = await dbContext.Contacts.FindAsync(id);
            if(contact!=null)
            {
                dbContext.Remove(contact);
                dbContext.SaveChanges();
                return Ok(contact);

            }
            return NotFound();
        }

    }
}
