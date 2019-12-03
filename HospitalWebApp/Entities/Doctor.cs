using HospitalWebApp.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

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

        [StringLength(50, MinimumLength = 2)]
        public string Specialization { get; set; }


        [Required(ErrorMessage = "Gender  Must be provided")]
        [StringLength(10, MinimumLength = 4)]
        public string Gender { get; set; }

        [Required(ErrorMessage = "DateOfBirth  Must be provided")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "JoinDate  Must be provided")]
        public DateTime JoinDate { get; set; }

        [Required(ErrorMessage = "Address  Must be provided")]
        [StringLength(250, MinimumLength = 2)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Mobile  Must be provided")]
        [StringLength(10, MinimumLength = 10)]
        public string Mobile { get; set; }



        public Boolean IsActive { get; set; }
        public String CreateOperator { get; set; }
        public String UpdateOperator { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
    }


}
