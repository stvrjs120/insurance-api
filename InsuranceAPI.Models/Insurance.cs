using InsuranceAPI.Models.EntityBase;
using InsuranceAPI.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceAPI.Models
{
    public class Insurance : Entity<int>
    {
        [Required]
        [Column(TypeName ="varchar(200)")]
        public string Description { get; set; }

        [Required]
        public Covering Covering { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ValidFrom { get; set; }

        [Required]
        public int CoverageTime { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public RiskLevel RiskLevel { get; set; }
    }
}
