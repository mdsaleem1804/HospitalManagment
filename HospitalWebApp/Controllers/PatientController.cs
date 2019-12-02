using System.Collections.Generic;
using HospitalWebApp.Interfaces;
using HospitalWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {

        IPatient<Patient, int> patientRepository;
        public PatientController(IPatient<Patient, int> personrepo)
        {
            patientRepository = personrepo;
        }

        [HttpGet]
        public IEnumerable<Patient> Get()
        {
            var patients = patientRepository.GetPatients();
            return patients;
        }
        [HttpPost]
        public IActionResult Post([FromBody] Patient p)
        {
            int res = patientRepository.AddPatient(p);
            if (res != 0)
            {
                return Ok();
            }
            return Forbid();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Patient p)
        {
            int res = patientRepository.UpdatePatient(id, p);
            if (res != 0)
            {
                return Ok();
            }
            return Forbid();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int res = patientRepository.DeletePatient(id);
            if(res!=0)
            {
                return Ok();
            }
            return Forbid();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var patient = patientRepository.GetPatient(id);
            if(patient==null)
            {
                return Ok();
            }
            return Ok(patient);
        }
    }
}