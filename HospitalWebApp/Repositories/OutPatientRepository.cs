using AutoMapper;
using HospitalWebApp.Data.Enums;
using HospitalWebApp.Entities;
using HospitalWebApp.Interfaces;
using HospitalWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWebApp.Repositories
{

    public class OutPatientRepository : IOutPatient<OutPatient, int>
    {
        ApplicationContext context;
        private readonly IMapper _mapper;
        public OutPatientRepository(ApplicationContext _context, IMapper mapper)
        {
            context = _context;
            _mapper = mapper;
        }

        public IEnumerable<OPViewModel> GetOutPatients()
        {

            var outpatients = context.OutPatients.Include(d => d.Doctor).Include(p => p.Patient).ToList();

            var result = new List<OPViewModel>();
            foreach (var outpatient in outpatients)
            {
                result.Add(_mapper.Map<OPViewModel>(outpatient));
            }

            return result;
        }
        public IEnumerable<OPViewModel> GetOPDateRange(DateTime fromDate, DateTime toDate)
        {
            var outpatients = context.OutPatients
                .Include(d => d.Doctor)
                .Include(p => p.Patient)
                .Where(s => s.Date.Date >= fromDate.Date && s.Date.Date <= toDate.Date).ToList();
            if (outpatients.Count <= 0 && outpatients == null)
                throw new Exception();
            var result = new List<OPViewModel>();
            foreach (var outpatient in outpatients)
            {
                result.Add(_mapper.Map<OPViewModel>(outpatient));
            }
            return result;
        }
        public IEnumerable<OPViewModel> GetOPByPatient(int patientid)
        {
            var outpatients = context.OutPatients
                .Include(d => d.Doctor)
                .Include(p => p.Patient)
                .Where(s => s.PatientId == patientid).ToList();
            if (outpatients.Count <= 0 && outpatients == null)
                throw new Exception();
            var result = new List<OPViewModel>();
            foreach (var outpatient in outpatients)
            {
                result.Add(_mapper.Map<OPViewModel>(outpatient));
            }
            return result;
        }
        public IEnumerable<OPViewModel> GetOPByDoctor(int doctorid)
        {
            var outpatients = context.OutPatients
                .Include(d => d.Doctor)
                .Include(p => p.Patient)
                .Where(s => s.DoctorId == doctorid).ToList();
            if (outpatients.Count <= 0 && outpatients == null)
                throw new Exception();
            var result = new List<OPViewModel>();
            foreach (var outpatient in outpatients)
            {
                result.Add(_mapper.Map<OPViewModel>(outpatient));
            }
            return result;
        }

        public IEnumerable<OPViewModel> GetOPByDoctorAndDateRange(int doctorid,DateTime fromDate, DateTime toDate)
        {
            var outpatients = context.OutPatients
                .Include(d => d.Doctor)
                .Include(p => p.Patient)
                .Where(s =>s.DoctorId==doctorid 
                           && s.Date.Date >= fromDate.Date 
                           && s.Date.Date <= toDate.Date)
                          .ToList();
            if (outpatients.Count <= 0 && outpatients == null)
                throw new Exception();
            var result = new List<OPViewModel>();
            foreach (var outpatient in outpatients)
            {
                result.Add(_mapper.Map<OPViewModel>(outpatient));
            }
            return result;
        }
        public IEnumerable<OPViewModel> GetOPByCaseType(int casetypeid)
        {
            var outpatients = context.OutPatients
                .Include(d => d.Doctor)
                .Include(p => p.Patient)
                .Where(s => s.CaseTypeId == casetypeid).ToList();
            if (outpatients.Count <= 0 && outpatients == null)
                throw new Exception();
            var result = new List<OPViewModel>();
            foreach (var outpatient in outpatients)
            {
                result.Add(_mapper.Map<OPViewModel>(outpatient));
            }
            return result;
        }

        public OutPatient GetOutPatient(int id)
        {
            var doctor = context.OutPatients.FirstOrDefault(p => p.OutPatientId == id);
            return doctor;
        }
        public int AddOutPatient(OutPatient p)
        {
            p.CreateDateTime = DateTime.Now;
            context.OutPatients.Add(p);
            int res = context.SaveChanges();
            return res;
        }

        public int UpdateOutPatient(int id, OutPatient p)
        {
            int res = 0;
            var op = context.OutPatients.Find(id);
            if (op != null)
            {
                op.PaymentStatus = p.PaymentStatus;
                op.UpdateDateTime = DateTime.Now;

                res = context.SaveChanges();
            }
            return res;
        }

        public int DeleteOutPatient(int id)
        {
            int res = 0;
            var op = context.OutPatients.Find(id);
            if (op != null)
            {
                op.IsActive = false;
                op.UpdateDateTime = DateTime.Now;
                res = context.SaveChanges();
            }
            return res;
        }

    }
}
