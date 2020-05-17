using System.Collections.Generic;
using APBD11.Models;
using APBD11.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD11.Controllers
{
    [ApiController]
    [Route("api/Doctors")]
    public class DoctorController : ControllerBase
    {
        public IDbService _dbService;

        public DoctorController(IDbService dbService)
        {
            _dbService = dbService;
        }
        
        [HttpGet]
        public IActionResult getDoctors()
        {
            ICollection<Doctor> doctors = _dbService.getDoctors();
            if (doctors == null)
                return BadRequest();
            return Ok(doctors);
        }

        [HttpPost]
        public IActionResult addDoctor(Doctor doctor)
        {
            Doctor newDoctor = _dbService.createDoctor(doctor);
            if (newDoctor == null)
                return BadRequest();
            return Ok(newDoctor);
        }

        [HttpPost("update")]
        public IActionResult updateDoctor(Doctor doctor)
        {
            Doctor newDoctor = _dbService.updateDoctor(doctor);
            if (newDoctor == null)
                return BadRequest();
            return Ok(newDoctor);        
        }

        [HttpDelete("deleate/{id}")]
        public IActionResult deleateDoctor(int id)
        {
            Doctor doctor = _dbService.deleateDoctor(id);
            if (doctor == null)
                return BadRequest();
            return Ok(doctor);
        }
    }
}