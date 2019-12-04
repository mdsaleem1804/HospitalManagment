using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWebApp.Models
{
    public class OutPatientModel
    {
        public int OutPatientId { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public DateTime OPEntryDate { get; set; }

        public Double Fees { get; set; }
    }
}
