using InsuranceAPI.Models.EntityBase;
using System.Collections.Generic;

namespace InsuranceAPI.Models
{
    public class Customer : Entity<int>
    {
        public List<Insurance> insurance { get; set; }
    }
}
