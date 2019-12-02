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

        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public Patient Doctor { get; set; }

        public String Description { get; set; }

        [Required(ErrorMessage = "Fees  Must be provided")]
        public Double Fees { get; set; }
        public Boolean IsActive { get; set; }
        public Char PaymentStatus { get; set; }
        public String CreateOperator { get; set; }
        public String UpdateOperator { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

    }
}
