﻿using InsuranceAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceAPI.ViewModels
{
    public class CustomerViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int insuranceId { get; set; }
        public IList<CustomerInsurance> customerInsurances { get; set; }
    }
}
