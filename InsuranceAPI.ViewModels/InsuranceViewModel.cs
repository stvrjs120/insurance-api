using InsuranceAPI.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceAPI.ViewModels
{
    public class InsuranceViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Covering covering { get; set; }
        public DateTime validFrom { get; set; }
        public int coverageTime { get; set; }
        public decimal price { get; set; }
        public RiskLevel riskLevel { get; set; }
    }
}
