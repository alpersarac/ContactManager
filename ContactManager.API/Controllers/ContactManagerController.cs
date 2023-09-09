using ContactManager.DataAccess.Repository.IRepository;
using ContactManager.Logger.IRepository;
using ContactManager.Models.DTO;
using ContactManager.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ContactManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactManagerController : ControllerBase
    {
        IUnitOfWork _unitOfWork;
        IContactManagerLoggerRepository _contactManagerLoggerRepository;
        public ContactManagerController(IUnitOfWork unitOfWork, IContactManagerLoggerRepository contactManagerLoggerRepository)
        {
            _unitOfWork = unitOfWork;
            _contactManagerLoggerRepository = contactManagerLoggerRepository;
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
            if (contact == null)
            {
                await _contactManagerLoggerRepository.AddLog(LogImportance.Information, "Contact could not found.");
                return NotFound("Contact could not found.");
            }
            return Ok(contact);

        }
        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] Contact contact)
        {
            
            if (ModelState.IsValid)
            {
                bool isEmailExists = await _unitOfWork.ContactManager.CheckExistingEmail(contact.email);
                if (isEmailExists) 
                {
                    await _contactManagerLoggerRepository.AddLog(LogImportance.Warning, "Email is in use.");
                    return BadRequest("Email is in use, it must be unique email address.");
                }
                bool result = await _unitOfWork.ContactManager.Create(contact);
                if (result)
                {
                    return Ok(contact);
                }

                return BadRequest();

            }
            return BadRequest("Contact could not created.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            bool result = await _unitOfWork.ContactManager.Delete(id);

            if (result)
            {
                return Ok("Contact deleted successfully");
            }
            await _contactManagerLoggerRepository.AddLog(LogImportance.Error, "Contact could not deleted.");
            return BadRequest("Contact could not deleted.");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact([FromBody] ContactDTO contactDTO, int id)
        {
            bool isEmailExists = await _unitOfWork.ContactManager.CheckExistingEmail(contactDTO.email);
            if (isEmailExists)
            {
                await _contactManagerLoggerRepository.AddLog(LogImportance.Warning, "Email is in use.");
                return BadRequest("Email is in use, it must be unique email address.");
            }

            bool result = await _unitOfWork.ContactManager.Update(contactDTO, id);
            if (result)
            {
                return Ok("Contact updated successfully");
            }
            return BadRequest("Failed to update contact");

        }

    }
}
