using System;
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
        public IEnumerable<OutPatientModel> Get()
        {
            var outpatients = OutPatientRepository.GetOutPatients();
            return outpatients;
        }

        [Route("GetOPDateRange")]
        [HttpGet]
        public IEnumerable<OutPatientModel> GetOPDateRange([FromBody] OpDateRangeInputModel request)
        {
            var outpatients = OutPatientRepository.GetOPDateRange(request.FromDate, request.ToDate);
            return outpatients;
        }

        [Route("GetOPByPatient")]
        [HttpGet]
        public IEnumerable<OutPatientModel> GetOPByPatient([FromBody] OPPatientInputModel request)
        {
            var outpatients = OutPatientRepository.GetOPByPatient(request.PatientId);
            return outpatients;
        }


        [Route("GetOPByDoctor")]  
        [HttpGet]
        public IEnumerable<OutPatientModel> GetOPByDoctor(int doctorid)
        {
            var outpatients = OutPatientRepository.GetOPByDoctor(doctorid);
            return outpatients;
        }

        //[Route("")]     // Matches 'api/OutPatient'
        //[Route("GetOPByDoctor")]  // Matches 'api/OutPatient/GetOPByDoctor'
        //[HttpGet("{doctorid}")]
        //public IEnumerable<OutPatientModel> GetOPByDoctor(int doctorid)
        //{
        //    var outpatients = OutPatientRepository.GetOPByDoctor(doctorid);
        //    return outpatients;
        //}
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