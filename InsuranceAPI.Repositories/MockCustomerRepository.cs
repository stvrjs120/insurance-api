using InsuranceAPI.Interfaces;
using InsuranceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InsuranceAPI.Repositories
{
    public class MockCustomerRepository : ICustomerRepository
    {
        private List<Customer> _customersList;
        private List<CustomerInsurance> _customerInsurancesList;
        private List<Insurance> _insurancesList;

        public MockCustomerRepository(List<CustomerInsurance> customerInsurances, List<Insurance> insurances)
        {
            _customerInsurancesList = customerInsurances;
            _insurancesList = insurances;

            _customersList = new List<Customer>()
            {
                new Customer()
                {
                    Id = 1,
                    Name = "Los Pollos Hermanos",
                    CustomerInsurances = null,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new Customer()
                {
                    Id = 2,
                    Name = "Carlos Urbina",
                    CustomerInsurances = null,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                }
            };
        }

        public Customer Create(Customer customer)
        {
            customer.Id = _customersList.Max(c => c.Id) + 1;
            _customersList.Add(customer);
            return customer;
        }

        public bool Delete(int id)
        {
            Customer customer = _customersList.FirstOrDefault(c => (c.Id == id));

            if (customer != null)
            {
                _customersList.Remove(customer);

                return true;
            }

            return false;
        }

        public IEnumerable<Customer> List()
        {
            return _customersList;
        }

        public Customer Read(int id)
        {
            return _customersList.FirstOrDefault(i => (i.Id == id));
        }

        public bool Update(Customer customerChanges)
        {
            Customer customer = _customersList.FirstOrDefault(i => i.Id == customerChanges.Id);

            if (customer != null)
            {
                customer.Name = customerChanges.Name;
                customer.ModifiedDate = DateTime.Now;

                return true;
            }

            return false;
        }

        public bool AssignInsurance(int customerId, int insuranceId)
        {
            IList<CustomerInsurance> existingItems = _customerInsurancesList
                .Where(ci => ci.CustomerID == customerId)
                .Where(ci => ci.InsuranceID == insuranceId).ToList();

            if (existingItems.Count == 0)
            {
                Customer customer = _customersList.FirstOrDefault(c => (c.Id == customerId));
                Insurance insurance = _insurancesList.FirstOrDefault(i => (i.Id == insuranceId));

                if (customer != null || insurance != null)
                {
                    var customerInsurance = new CustomerInsurance()
                    {
                        Customer = customer,
                        Insurance = insurance,
                    };

                    customer.CustomerInsurances.Add(customerInsurance);

                    return true;
                }
            }

            return false;
        }

        public bool RemoveInsurance(int customerId, int insuranceId)
        {
            CustomerInsurance customerInsurance = _customerInsurancesList
                .Where(ci => ci.CustomerID == customerId)
                .Where(ci => ci.InsuranceID == insuranceId).FirstOrDefault();

            if (customerInsurance != null)
            {
                _customerInsurancesList.Remove(customerInsurance);

                return true;
            }

            return false;
        }
    }
}
