using Claud.Models;
using Claud.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace GravyTrain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceCallController : Controller
    {
        private readonly IServiceCallRepository _ServiceCallRepository;
        private readonly IUserProfileRepository _UserProfileRepository;

        public ServiceCallController(IServiceCallRepository serviceCallRepository, IUserProfileRepository userProfileRepository)
        {
            _ServiceCallRepository = serviceCallRepository;
            _UserProfileRepository = userProfileRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<ServiceCall> serviceCalls = _ServiceCallRepository.GetAllServiceCalls();

            if (serviceCalls == null)
            {
                return NotFound();
            }

            return Ok(serviceCalls);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ServiceCall serviceCall = _ServiceCallRepository.GetServiceCallById(id);
           
            if (serviceCall == null)
            {
                return NotFound();
            }
            return Ok(serviceCall);
        }




        [HttpGet("User/{userId}")]
        public IActionResult GetByUserId(int userId)
        {

            List<ServiceCall> serviceCalls = _ServiceCallRepository.GetServiceCallsByUserId(userId);

            if (serviceCalls == null)
            {
                return NotFound();
            }

            return Ok(serviceCalls);
        }


        [HttpPost]
        public IActionResult Post(ServiceCall serviceCall)
        {
            serviceCall.DateScheduled = DateTime.Now;
            _ServiceCallRepository.Add(serviceCall);
            return CreatedAtAction("Get", new { id = serviceCall.Id }, serviceCall);
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, ServiceCall serviceCall)
        {
            if (id != serviceCall.Id)
            {
                return BadRequest();
            }

            _ServiceCallRepository.Update(serviceCall);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _ServiceCallRepository.Delete(id);
            return NoContent();
        }


        private UserProfile GetCurrentUserProfile()
        {
            var firebaseUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _UserProfileRepository.GetByFirebaseUserId(firebaseUserId);
        }
    }
}
