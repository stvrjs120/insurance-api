using InsuranceAPI.Models.EntityBase;
using System.ComponentModel.DataAnnotations;

namespace InsuranceAPI.Models
{
    public class CustomerInsurance
    {
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        public int InsuranceID { get; set; }
        public Insurance Insurance { get; set; }
    }
}
