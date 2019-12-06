using HospitalWebApp.Interfaces;
using HospitalWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWebApp.Repositories
{

    public class PatientRepository: IPatient<Patient,int>
    {
        ApplicationContext context;
        public PatientRepository(ApplicationContext _context)
        {
            context = _context;
        }

        public IEnumerable<Patient> GetPatients()
        {
            var patients = context.Patients.ToList();
            return patients;
        }

        public int AddPatient(Patient p)
        {
            context.Patients.Add(p);
            int res = context.SaveChanges();
            return res;
        }

        public int UpdatePatient(int id,Patient p)
        {
            int res = 0;
            var patient = context.Patients.Find(id);
            if(patient!=null)
            {
                patient.Name = p.Name;
                patient.Address = p.Address;
                res = context.SaveChanges();
            }
            return res; 
        }

        public int DeletePatient(int id)
        {
            int res = 0;
            var patient = context.Patients.Find(id);
            if (patient != null)
            {
                patient.IsActive = false;
                res = context.SaveChanges();
            }
            return res;
        }

        public Patient GetPatient(int id)
        {
            var patient = context.Patients.FirstOrDefault(p => p.PatientId == id);
            return patient;
        }
    }
}
