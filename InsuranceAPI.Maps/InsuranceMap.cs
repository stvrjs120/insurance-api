using InsuranceAPI.Interfaces;
using InsuranceAPI.Models;
using InsuranceAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceAPI.Maps
{
    public class InsuranceMap : IInsuranceMap
    {
        private IInsuranceService insuranceService;

        public InsuranceMap(IInsuranceService service)
        {
            insuranceService = service;
        }

        public InsuranceViewModel Create(InsuranceViewModel viewModel)
        {
            Insurance insurance = ViewModelToDomain(viewModel);

            return DomainToViewModel(insuranceService.Create(insurance));
        }

        public InsuranceViewModel Read(int id)
        {
            return DomainToViewModel(insuranceService.Read(id));
        }

        public bool Update(InsuranceViewModel viewModel)
        {
            Insurance insurance = ViewModelToDomain(viewModel);

            return insuranceService.Update(insurance);
        }

        public bool Delete(int id)
        {
            return insuranceService.Delete(id);
        }

        public IEnumerable<InsuranceViewModel> List()
        {
            return DomainToViewModel(insuranceService.List());
        }

        private InsuranceViewModel DomainToViewModel(Insurance domain)
        {
            InsuranceViewModel model = new InsuranceViewModel();
            model.id = domain.Id;
            model.name = domain.Name;
            model.description = domain.Description;
            model.covering = domain.Covering;
            model.validFrom = domain.ValidFrom;
            model.coverageTime = domain.CoverageTime;
            model.price = domain.Price;
            model.riskLevel = domain.RiskLevel;

            return model;
        }

        private List<InsuranceViewModel> DomainToViewModel(IEnumerable<Insurance> domain)
        {
            List<InsuranceViewModel> model = new List<InsuranceViewModel>();

            foreach (Insurance of in domain)
            {
                model.Add(DomainToViewModel(of));
            }

            return model;
        }

        private Insurance ViewModelToDomain(InsuranceViewModel officeViewModel)
        {
            Insurance domain = new Insurance();

            domain.Id = officeViewModel.id;
            domain.Name = officeViewModel.name;
            domain.Description = officeViewModel.description;
            domain.Covering = officeViewModel.covering;
            domain.ValidFrom = officeViewModel.validFrom;
            domain.CoverageTime = officeViewModel.coverageTime;
            domain.Price = officeViewModel.price;
            domain.RiskLevel = officeViewModel.riskLevel;

            return domain;
        }
    }
}
