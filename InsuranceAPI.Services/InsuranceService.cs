using InsuranceAPI.Interfaces;
using InsuranceAPI.Models;
using System.Collections.Generic;

namespace InsuranceAPI.Services
{
    public class InsuranceService : IInsuranceService
    {
        private readonly IInsuranceRepository repository;

        public InsuranceService(IInsuranceRepository insuranceRepository)
        {
            repository = insuranceRepository;
        }

        public Insurance Create(Insurance insurance)
        {
            return repository.Create(insurance);
        }

        public bool Delete(int id)
        {
            return repository.Delete(id);
        }

        public IEnumerable<Insurance> List()
        {
            return repository.List();
        }

        public Insurance Read(int id)
        {
            return repository.Read(id);
        }

        public bool Update(Insurance insuranceChanges)
        {
            return repository.Update(insuranceChanges);
        }
    }
}
