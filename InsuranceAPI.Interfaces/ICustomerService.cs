using InsuranceAPI.Models;
using System.Collections.Generic;

namespace InsuranceAPI.Interfaces
{
    public interface ICustomerService
    {
        Customer Create(Customer customer);
        Customer Read(int id);
        bool Update(Customer customerChanges);
        bool Delete(int id);
        IEnumerable<Customer> List();
        bool AssignInsurance(int customerId, int insuranceId);
        IEnumerable<CustomerInsurance> ListCustomerInsurances(int customerId);
        bool RemoveInsurance(int customerId, int insuranceId);
    }
}
