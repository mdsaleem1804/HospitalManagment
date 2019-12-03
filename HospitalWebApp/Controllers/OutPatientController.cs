using System.Collections.Generic;
using HospitalWebApp.Entities;
using HospitalWebApp.Interfaces;
using HospitalWebApp.Models;
using HospitalWebApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HospitalWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutPatientController : ControllerBase
    {

        IOutPatient<OutPatient, int> OutPatientRepository;
        public OutPatientController(IOutPatient<OutPatient, int> oprepo)
        {
            OutPatientRepository = oprepo;
        }

        [HttpGet]
        public IEnumerable<OutPatient> Get()
        {
            var outpatients = OutPatientRepository.GetOutPatients();
            return outpatients;
        }
        [HttpPost]
        public IActionResult Post([FromBody] OutPatient p)
        {
            int res = OutPatientRepository.AddOutPatient(p);
            if (res != 0)
            {
                return Ok();
            }
            return Forbid();
        } 

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] OutPatient p)
        {
            int res = OutPatientRepository.UpdateOutPatient(id, p);
            if (res != 0)
            {
                return Ok();
            }
            return Forbid();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int res = OutPatientRepository.DeleteOutPatient(id);
            if (res != 0)
            {
                return Ok();
            }
            return Forbid();
        }
    }
}