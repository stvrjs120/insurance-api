using InsuranceAPI.Interfaces;
using InsuranceAPI.Models;
using System.Collections.Generic;

namespace InsuranceAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository repository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            repository = customerRepository;
        }

        public bool AssignInsurance(int customerId, int insuranceId)
        {
            return repository.AssignInsurance(customerId, insuranceId);
        }

        public IEnumerable<CustomerInsurance> ListCustomerInsurances(int customerId)
        {
            return repository.ListCustomerInsurances(customerId);
        }

        public bool RemoveInsurance(int customerId, int insuranceId)
        {
            return repository.RemoveInsurance(customerId, insuranceId);
        }

        public Customer Create(Customer customer)
        {
            return repository.Create(customer);
        }

        public bool Delete(int id)
        {
            return repository.Delete(id);
        }

        public IEnumerable<Customer> List()
        {
            return repository.List();
        }

        public Customer Read(int id)
        {
            return repository.Read(id);
        }

        public bool Update(Customer customerChanges)
        {
            return repository.Update(customerChanges);
        }
    }
}
