using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceAPI.ViewModels
{
    public class CustomerInsuranceViewModel
    {
        public int customerID { get; set; }
        public CustomerViewModel customer { get; set; }

        public int insuranceID { get; set; }
        public InsuranceViewModel insurance { get; set; }
    }
}
