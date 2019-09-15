using InsuranceAPI.Interfaces;
using InsuranceAPI.Models;
using InsuranceAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceAPI.Maps
{
    public class CustomerMap : ICustomerMap
    {
        private ICustomerService customerService;

        public CustomerMap(ICustomerService service)
        {
            customerService = service;
        }

        public CustomerViewModel Create(CustomerViewModel viewModel)
        {
            Customer customer = ViewModelToDomain(viewModel);

            return DomainToViewModel(customerService.Create(customer));
        }

        public CustomerViewModel Read(int id)
        {
            return DomainToViewModel(customerService.Read(id));
        }

        public bool Update(CustomerViewModel viewModel)
        {
            Customer customer = ViewModelToDomain(viewModel);

            return customerService.Update(customer);
        }

        public bool Delete(int id)
        {
            return customerService.Delete(id);
        }

        public List<CustomerViewModel> List()
        {
            return DomainToViewModel(customerService.List());
        }

        public bool AssignInsurance(int customerId, int insuranceId)
        {
            return customerService.AssignInsurance(customerId, insuranceId);
        }

        public bool RemoveInsurance(int customerId, int insuranceId)
        {
            return customerService.RemoveInsurance(customerId, insuranceId);
        }

        private CustomerViewModel DomainToViewModel(Customer domain)
        {
            CustomerViewModel model = new CustomerViewModel();
            model.id = domain.Id;
            model.name = domain.Name;

            return model;
        }

        private List<CustomerViewModel> DomainToViewModel(IEnumerable<Customer> domain)
        {
            List<CustomerViewModel> model = new List<CustomerViewModel>();

            foreach (Customer of in domain)
            {
                model.Add(DomainToViewModel(of));
            }

            return model;
        }

        private Customer ViewModelToDomain(CustomerViewModel officeViewModel)
        {
            Customer domain = new Customer();

            domain.Id = officeViewModel.id;
            domain.Name = officeViewModel.name;

            return domain;
        }
    }
}
