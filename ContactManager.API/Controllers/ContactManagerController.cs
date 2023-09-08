using ContactManager.DataAccess.Repository.IRepository;
using ContactManager.Models.DTO;
using ContactManager.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactManagerController : ControllerBase
    {
        IUnitOfWork _unitOfWork;
        public ContactManagerController(IUnitOfWork unitOfWork) 
        { 
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllContacts()
        {
            List<Contact> AllContacts = await _unitOfWork.ContactManager.GetAll();

            return Ok(AllContacts);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            Contact contact = await _unitOfWork.ContactManager.GetById(id);
            if (contact==null)
            {
                return NotFound("Contact could not found.");
            }
            return Ok(contact);

        }
        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] Contact contact)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.ContactManager.Create(contact);
                return Ok(contact);
            }
            return BadRequest("Contact could not created.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            bool result = await _unitOfWork.ContactManager.Delete(id);

            if (result)
            {
                return Ok();
            }
            return BadRequest("Contact could not updated.");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact([FromBody] ContactDTO contactDTO, int id)
        {
            bool result = await _unitOfWork.ContactManager.Update(contactDTO,id);
            if (result)
            {
                return Ok("Contact updated successfully");
            }
            else
            {
                return BadRequest("Failed to update contact");
            }
        }

    }
}
