using HospitalWebApp.Interfaces;
using HospitalWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWebApp.Repositories
{

    public class DoctorRepository : IDoctor<Doctor, int>
    {
        ApplicationContext context;
        public DoctorRepository(ApplicationContext _context)
        {
            context = _context;
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            var doctors = context.Doctors.ToList();
            return doctors;
        }

        public int AddDoctor(Doctor p)
        {
            context.Doctors.Add(p);
            int res = context.SaveChanges();
            return res;
        }

        public int UpdateDoctor(int id,Doctor p)
        {
            int res = 0;
            var doctor = context.Doctors.Find(id);
            if(doctor != null)
            {
                doctor.DoctorName = p.DoctorName;
                res = context.SaveChanges();
            }
            return res; 
        }

        public int DeleteDoctor(int id)
        {
            int res = 0;
            var doctor = context.Doctors.FirstOrDefault(p => p.DoctorId == id);
            if(doctor != null)
            {
                context.Doctors.Remove(doctor);
                res = context.SaveChanges();
            }
            return res;
        }

        public Doctor GetDoctor(int id)
        {
            var doctor = context.Doctors.FirstOrDefault(p => p.DoctorId == id);
            return doctor;
        }
    }
}
