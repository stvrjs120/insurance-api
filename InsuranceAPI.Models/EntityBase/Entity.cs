using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceAPI.Models.EntityBase
{
    public abstract class Entity<T> : IEntity<T>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; }
        object IEntity.Id
        {
            get { return this.Id; }
        }

        [Required]
        [Column(TypeName = "varchar(200)")]
        public string Name { get; set; }

        private DateTime? createdDate;
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate
        {
            get { return createdDate ?? DateTime.UtcNow; }
            set { createdDate = value; }
        }

        [DataType(DataType.DateTime)]
        public DateTime? ModifiedDate { get; set; }

    }
}
