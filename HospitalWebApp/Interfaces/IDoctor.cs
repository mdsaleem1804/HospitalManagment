using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWebApp.Interfaces
{
    public interface IDoctor<TEntity, T> where TEntity : class
    {
        IEnumerable<TEntity> GetDoctors();
        int AddDoctor(TEntity p);

        int UpdateDoctor(T id, TEntity p);

        int DeleteDoctor(int id);

        TEntity GetDoctor(T id);
    }
    
}
