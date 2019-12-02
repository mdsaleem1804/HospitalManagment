using HospitalWebApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWebApp.Models
{
    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Name  Must be provided")]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address  Must be provided")]
        [StringLength(250, MinimumLength = 2)]
        public string Address { get; set; }


        public ICollection<OutPatient> OutPatients { get; set; }
    }
}
