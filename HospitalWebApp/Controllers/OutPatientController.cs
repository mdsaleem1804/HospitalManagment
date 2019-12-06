using System;
using System.Collections.Generic;
using AutoMapper;
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
        private readonly IMapper _mapper;
        public OutPatientController(IOutPatient<OutPatient, int> oprepo, IMapper mapper)
        {
            OutPatientRepository = oprepo;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<OPViewModel> Get()
        {
            var outpatients = OutPatientRepository.GetOutPatients();
            return outpatients;
        }

        [Route("GetOPDateRange")]
        [HttpGet]
        public IEnumerable<OPViewModel> GetOPDateRange([FromBody] OPInputModel request)
        {
            var outpatients = OutPatientRepository.GetOPDateRange(request.FromDate, request.ToDate);
            return outpatients;
        }

        [Route("GetOPByPatient")]
        [HttpGet]
        public IEnumerable<OPViewModel> GetOPByPatient([FromBody] OPInputModel request)
        {
            var outpatients = OutPatientRepository.GetOPByPatient(request.PatientId);
            return outpatients;
        }

        [Route("GetOPByDoctor")]
        [HttpGet]
        public IEnumerable<OPViewModel> GetOPByDoctor([FromBody] OPInputModel request)
        {
            var outpatients = OutPatientRepository.GetOPByDoctor(request.DoctorId);
            return outpatients;
        }
        [Route("GetOPByDoctorAndDateRange")]
        [HttpGet]
        public IEnumerable<OPViewModel> GetOPByDoctorAndDateRange([FromBody] OPInputModel request)
        {
            var outpatients = OutPatientRepository.GetOPByDoctorAndDateRange(request.DoctorId, request.FromDate, request.ToDate);
            return outpatients;
        }
        [Route("GetOPByCaseType")]
        [HttpGet]
        public IEnumerable<OPViewModel> GetOPByCaseType([FromBody] OPInputModel request)
        {
            var outpatients = OutPatientRepository.GetOPByCaseType(request.CaseTypeId);
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