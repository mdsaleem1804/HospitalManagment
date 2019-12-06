using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace HospitalWebApp.Entities
{
    public class CaseType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CaseTypeId { get; set; }

        [Required(ErrorMessage = "Description   Must be provided")]
        [StringLength(50, MinimumLength = 2)]
        public string Description { get; set; }

        public Boolean IsActive { get; set; }
        public String CreateOperator { get; set; }
        public String UpdateOperator { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
    }
}
