using CumbinaTelefonaraWebAPI.Core;
using CumbinaTelefonaraWebAPI.Data;
using CumbinaTelefonaraWebAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace CumbinaTelefonaraWebAPI.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private static IUnitOfWork _unitOfWork;

        public PhoneController(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetAllPhones")]
        public async Task<IActionResult> Get()
        {
            var phones = await _unitOfWork.Phones.GetAll();
            return Ok(phones);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> Get(int id)
        {
            var phone = await _unitOfWork.Phones.GetById(id);
            if(phone == null)
                return NotFound();

            return Ok(phone);
        }

        [HttpPost]
        [Route("AddPhone")]
        public async Task<IActionResult> Post(Phone phone)
        {

            await _unitOfWork.Phones.Add(phone);
            await _unitOfWork.CompleteAsync();
            return Ok();
        }

        [HttpPatch]
        [Route("UpdatePhone")]
        public async Task<IActionResult> Update(Phone phone)
        {
            var existingPhone = await _unitOfWork.Phones.GetById(phone.Id);

            if (existingPhone == null)
                return NotFound();

            await _unitOfWork.Phones.Update(existingPhone);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpDelete]
        [Route("DeletePhone")]
        public async Task<IActionResult> Delete(int id)
        {
            var phone = await _unitOfWork.Phones.GetById(id);

            if (phone == null)
                return NotFound();

            await _unitOfWork.Phones.Delete(phone);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
