using HospitalWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWebApp.Interfaces
{
    public interface IOutPatient<TEntity, T> where TEntity : class
    {
        IEnumerable<OPViewModel> GetOutPatients();

        TEntity GetOutPatient(T id);
        IEnumerable<OPViewModel> GetOPDateRange(DateTime d1, DateTime d2);
        IEnumerable<OPViewModel> GetOPByPatient(int patientid);
        IEnumerable<OPViewModel> GetOPByDoctor(int doctorid);
        IEnumerable<OPViewModel> GetOPByDoctorAndDateRange(int doctorid,DateTime d1, DateTime d2);
        IEnumerable<OPViewModel> GetOPByCaseType(int doctorid);
        int AddOutPatient(TEntity t);

        int UpdateOutPatient(T id, TEntity t);

        int DeleteOutPatient(int id);
    }
}
