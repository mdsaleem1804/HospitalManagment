using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace HospitalWebApp.Entities
{
    public class Relationship
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RelationshipId { get; set; }

        [Required(ErrorMessage = "Relationship Name  Must be provided")]
        [StringLength(50, MinimumLength = 2)]
        public string Description { get; set; }

        public Boolean IsActive { get; set; }
        public String CreateOperator { get; set; }
        public String UpdateOperator { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
    }
}
