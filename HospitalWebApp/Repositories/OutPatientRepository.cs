﻿using HospitalWebApp.Entities;
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
        public OutPatientRepository(ApplicationContext _context)
        {
            context = _context;
        }

        public IEnumerable<OutPatientModel> GetOutPatients()
        {

            var outpatients = context.OutPatients.Include(d => d.Doctor).Include(p => p.Patient).ToList();

            List<OutPatientModel> result = IterateOP(outpatients);

            return result;
        }
        public IEnumerable<OutPatientModel> GetOPDateRange(DateTime fromDate, DateTime toDate)
        {
            var outpatients = context.OutPatients
                .Include(d => d.Doctor)
                .Include(p => p.Patient)
                .Where(s => s.Date.Date >= fromDate.Date && s.Date.Date <= toDate.Date).ToList();
            if (outpatients.Count <= 0 && outpatients == null)
                throw new Exception();
            List<OutPatientModel> result = IterateOP(outpatients);
            return result;
        }
        public IEnumerable<OutPatientModel> GetOPByPatient(int patientid)
        {
            var outpatients = context.OutPatients
                .Include(d => d.Doctor)
                .Include(p => p.Patient)
                .Where(s => s.PatientId == patientid).ToList();
            if (outpatients.Count <= 0 && outpatients == null)
                throw new Exception();
            List<OutPatientModel> result = IterateOP(outpatients);

            return result;
        }
        public IEnumerable<OutPatientModel> GetOPByDoctor(int doctorid)
        {
            var outpatients = context.OutPatients
                .Include(d => d.Doctor)
                .Include(p => p.Patient)
                .Where(s => s.DoctorId == doctorid).ToList();
            if (outpatients.Count <= 0 && outpatients == null)
                throw new Exception();
            List<OutPatientModel> result = IterateOP(outpatients);
            return result;
        }
        private static List<OutPatientModel> IterateOP(List<OutPatient> outpatients)
        {
            var result = new List<OutPatientModel>();
            foreach (var outpatient in outpatients)
            {
                var singleopmodel = new OutPatientModel()
                {
                    OutPatientId = outpatient.OutPatientId,
                    OPEntryDate = outpatient.Date,
                    DoctorName = outpatient.Doctor.DoctorName,
                    PatientName = outpatient.Patient.Name,
                    Fees = outpatient.Fees
                };
                result.Add(singleopmodel);
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
            context.OutPatients.Add(p);
            int res = context.SaveChanges();
            return res;
        }

        public int UpdateOutPatient(int id, OutPatient p)
        {
            int res = 0;
            var doctor = context.OutPatients.Find(id);
            if (doctor != null)
            {
                doctor.PaymentStatus = p.PaymentStatus;
                res = context.SaveChanges();
            }
            return res;
        }

        public int DeleteOutPatient(int id)
        {
            int res = 0;
            var op = context.OutPatients.FirstOrDefault(p => p.OutPatientId == id);
            if (op != null)
            {
                context.OutPatients.Remove(op);
                res = context.SaveChanges();
            }
            return res;
        }

    }
}
