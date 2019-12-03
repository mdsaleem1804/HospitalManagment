using HospitalWebApp.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HospitalWebApp.Entities
{
    public class OutPatient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OutPatientId { get; set; }

        [Required(ErrorMessage = "Date  Must be provided")]
        public DateTime Date { get; set; }

        public Patient Patient { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Doctor Doctor { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }

        public CaseType CaseType { get; set; }
        [ForeignKey("CaseType")]
        public int CaseTypeId { get; set; }
        public String Description { get; set; }

        [Required(ErrorMessage = "Fees  Must be provided")]
        public Double Fees { get; set; }
        public Char PaymentStatus { get; set; }

        public Boolean IsActive { get; set; }
        public String CreateOperator { get; set; }
        public String UpdateOperator { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }

    }
}
