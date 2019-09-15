using InsuranceAPI.Models;
using InsuranceAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceAPI.Interfaces
{
    public interface ICustomerMap
    {
        CustomerViewModel Create(CustomerViewModel viewModel);
        CustomerViewModel Read(int id);
        bool Update(CustomerViewModel viewModel);
        bool Delete(int id);
        List<CustomerViewModel> List();
        bool AssignInsurance(int customerId, int insuranceId);
        bool RemoveInsurance(int customerId, int insuranceId);
    }
}
