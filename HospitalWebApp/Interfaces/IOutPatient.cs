using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWebApp.Interfaces
{
    public interface IOutPatient<TEntity, T> where TEntity : class
    {
        IEnumerable<TEntity> GetOutPatients();
    
        TEntity GetOutPatient(T id);

        int AddOutPatient(TEntity t);

        int UpdateOutPatient(T id, TEntity t);

        int DeleteOutPatient(int id);
    }
}
