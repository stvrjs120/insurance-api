using InsuranceAPI.Interfaces;
using InsuranceAPI.Models;
using InsuranceAPI.Models.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace InsuranceAPI.Repositories
{
    public class SQLCustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDBContext context;

        public SQLCustomerRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

        public Customer Create(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
            return customer;
        }

        public bool Delete(int id)
        {
            Customer customer = context.Customers.Find(id);
            if (customer != null)
            {
                context.Customers.Remove(customer);
                context.SaveChanges();

                return true;
            }

            return false;
        }

        public IEnumerable<Customer> List()
        {
            return context.Customers;
        }

        public Customer Read(int id)
        {
            return context.Customers.Find(id);
        }

        public bool Update(Customer customerChanges)
        {
            var customer = context.Customers.Attach(customerChanges);

            if (customer != null)
            {
                customer.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();

                return true;
            }

            return false;
        }

        public bool AssignInsurance(int customerId, int insuranceId)
        {
            IList<CustomerInsurance> existingItems = context.CustomerInsurances
                .Where(ci => ci.CustomerID == customerId)
                .Where(ci => ci.InsuranceID == insuranceId).ToList();

            if (existingItems.Count == 0)
            {
                Customer customer = context.Customers.Where(c => (c.Id == customerId)).Include(c => (c.CustomerInsurances)).FirstOrDefault();
                Insurance insurance = context.Insurances.Where(i => (i.Id == insuranceId)).FirstOrDefault();

                if (customer != null && insurance != null)
                {
                    var customerInsurance = new CustomerInsurance()
                    {
                        Customer = customer,
                        Insurance = insurance
                    };

                    customer.CustomerInsurances.Add(customerInsurance);
                    context.SaveChanges();

                    return true;
                }
            }

            return false;
        }

        public IEnumerable<CustomerInsurance> ListCustomerInsurances(int customerId)
        {
            var customerInsurances = context.CustomerInsurances.Where(i => (i.CustomerID == customerId)).FirstOrDefault();

            return null;
        }

        public bool RemoveInsurance(int customerId, int insuranceId)
        {
            CustomerInsurance customerInsurance = context.CustomerInsurances
                .Where(ci => ci.CustomerID == customerId)
                .Where(ci => ci.InsuranceID == insuranceId).FirstOrDefault();

            if (customerInsurance != null)
            {
                context.CustomerInsurances.Remove(customerInsurance);
                context.SaveChanges();

                return true;
            }

            return false;
        }

    }
}
