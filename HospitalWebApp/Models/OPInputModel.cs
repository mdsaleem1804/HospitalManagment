using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWebApp.Models
{
    public class OPInputModel
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int CaseTypeId { get; set; }
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }
    }
}
