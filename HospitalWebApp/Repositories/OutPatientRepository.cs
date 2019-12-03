using HospitalWebApp.Entities;
using HospitalWebApp.Interfaces;
using HospitalWebApp.Models;
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

        public IEnumerable<OutPatient> GetOutPatients()
        {
            var outpatients = context.OutPatients.ToList();
            return outpatients;
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
