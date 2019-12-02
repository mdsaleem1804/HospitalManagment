using System.Collections.Generic;
using HospitalWebApp.Interfaces;
using HospitalWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {

        IDoctor<Doctor, int> DoctorRepository;
        public DoctorController(IDoctor<Doctor, int> doctorrepo)
        {
            DoctorRepository = doctorrepo;
        }

        [HttpGet]
        public IEnumerable<Doctor> Get()
        {
            var Doctors = DoctorRepository.GetDoctors();
            return Doctors;
        }
        [HttpPost]
        public IActionResult Post([FromBody] Doctor p)
        {
            int res = DoctorRepository.AddDoctor(p);
            if (res != 0)
            {
                return Ok();
            }
            return Forbid();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Doctor p)
        {
            int res = DoctorRepository.UpdateDoctor(id, p);
            if (res != 0)
            {
                return Ok();
            }
            return Forbid();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int res = DoctorRepository.DeleteDoctor(id);
            if (res != 0)
            {
                return Ok();
            }
            return Forbid();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Doctor = DoctorRepository.GetDoctor(id);
            if (Doctor == null)
            {
                return Ok();
            }
            return Ok(Doctor);
        }
    }
}