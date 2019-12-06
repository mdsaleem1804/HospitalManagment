using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWebApp.Models
{
    public class OPViewModel
    {
        public int OutPatientId { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public DateTime OPEntryDate { get; set; }
        public string PaymentStatus { get; set; }
        public Double Fees { get; set; }

        public string CreateOperator { get; set; }
        public string UpdateOperator { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
    }
}
