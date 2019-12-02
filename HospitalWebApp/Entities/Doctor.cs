using HospitalWebApp.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalWebApp.Models
{
    public class Doctor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Doctor Name  Must be provided")]
        [StringLength(50, MinimumLength = 2)]
        public string DoctorName { get; set; }


        public ICollection<OutPatient> OutPatients { get; set; }
    }
}
