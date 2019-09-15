using InsuranceAPI.Models;
using InsuranceAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceAPI.Interfaces
{
    public interface IInsuranceMap
    {
        InsuranceViewModel Create(InsuranceViewModel viewModel);
        InsuranceViewModel Read(int id);
        bool Update(InsuranceViewModel viewModel);
        bool Delete(int id);
        IEnumerable<InsuranceViewModel> List();
    }
}
