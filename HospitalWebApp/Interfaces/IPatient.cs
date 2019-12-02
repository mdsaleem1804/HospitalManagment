using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWebApp.Interfaces
{
    public interface IPatient<TEntity, T> where TEntity:class
    {
        IEnumerable<TEntity> GetPatients();
        int AddPatient(TEntity p);

        int UpdatePatient(T id, TEntity p);

        int DeletePatient(int id);

        TEntity GetPatient(T id);
    }
    
}




