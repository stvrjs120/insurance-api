using InsuranceAPI.Models.EntityBase;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceAPI.Models
{
    public class Customer : Entity<int>
    {
        public IList<CustomerInsurance> CustomerInsurances { get; set; }
    }
}
