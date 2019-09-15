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
        private readonly ICustomerService customerService;

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

        public IEnumerable<CustomerInsuranceViewModel> ListCustomerInsurances(int customerId)
        {
            return DomainToViewModel(customerService.ListCustomerInsurances(customerId));
        }

        public bool RemoveInsurance(int customerId, int insuranceId)
        {
            return customerService.RemoveInsurance(customerId, insuranceId);
        }

        private CustomerInsuranceViewModel DomainToViewModel(CustomerInsurance domain)
        {
            CustomerInsuranceViewModel model = new CustomerInsuranceViewModel();
            model.insurance.id = domain.Insurance.Id;
            model.insurance.name = domain.Insurance.Name;
            model.insurance.description = domain.Insurance.Description;
            model.insurance.coverageTime = domain.Insurance.CoverageTime;
            model.insurance.covering = domain.Insurance.Covering;
            model.insurance.riskLevel = domain.Insurance.RiskLevel;
            model.insurance.validFrom = domain.Insurance.ValidFrom;
            model.customerID = domain.CustomerID;
            model.insuranceID = domain.InsuranceID;

            return model;
        }

        private List<CustomerInsuranceViewModel> DomainToViewModel(IEnumerable<CustomerInsurance> domain)
        {
            List<CustomerInsuranceViewModel> model = new List<CustomerInsuranceViewModel>();

            foreach (CustomerInsurance of in domain)
            {
                model.Add(DomainToViewModel(of));
            }

            return model;
        }

        private CustomerViewModel DomainToViewModel(Customer domain)
        {
            CustomerViewModel model = new CustomerViewModel();
            model.id = domain.Id;
            model.name = domain.Name;
            model.customerInsurances = domain.CustomerInsurances;

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
            domain.CustomerInsurances = officeViewModel.customerInsurances;

            return domain;
        }
    }
}
