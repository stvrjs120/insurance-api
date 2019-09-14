using System;
using System.Collections.Generic;
using System.Linq;
using InsuranceAPI.Interfaces;
using InsuranceAPI.Models;

namespace InsuranceAPI.Repositories
{
    public class MockInsuranceRepository : IInsuranceRepository
    {
        private List<Insurance> _insuranceList;

        public MockInsuranceRepository()
        {
            _insuranceList = new List<Insurance>()
            {
                new Insurance() {
                    Id = 1,
                    Name = "Seguro Familiar",
                    Description = "Seguro cubre hijos y conyugue",
                    Covering = Models.Enums.Covering.Incendio,
                    ValidFrom = new DateTime(2019, 03, 14),
                    CoverageTime = 8,
                    Price = 120,
                    RiskLevel = Models.Enums.RiskLevel.MedioAlto,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new Insurance() {
                    Id = 2,
                    Name = "Seguro Viajes",
                    Description = "Seguro para viajes al extrangero",
                    Covering = Models.Enums.Covering.Robo,
                    ValidFrom = new DateTime(2019, 03, 14),
                    CoverageTime = 8,
                    Price = 160,
                    RiskLevel = Models.Enums.RiskLevel.Medio,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new Insurance() {
                    Id = 3,
                    Name = "Seguro Vivienda",
                    Description = "Seguro para daños a la vivienda",
                    Covering = Models.Enums.Covering.Incendio,
                    ValidFrom = new DateTime(2019, 03, 14),
                    CoverageTime = 8,
                    Price = 70,
                    RiskLevel = Models.Enums.RiskLevel.MedioAlto,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                }
            };
        }

        public Insurance Create(Insurance insurance)
        {
            insurance.Id = _insuranceList.Max(i => i.Id) + 1;
            _insuranceList.Add(insurance);
            return insurance;
        }

        public bool Delete(int id)
        {
            Insurance insurance = _insuranceList.FirstOrDefault(i => i.Id == id);

            if (insurance != null)
            {
                _insuranceList.Remove(insurance);

                return true;
            }

            return false;
        }

        public IEnumerable<Insurance> List()
        {
            return _insuranceList;
        }

        public Insurance Read(int id)
        {
            return _insuranceList.FirstOrDefault(i => i.Id == id);
        }

        public bool Update(Insurance insuranceChanges)
        {
            Insurance insurance = _insuranceList.FirstOrDefault(i => i.Id == insuranceChanges.Id);

            if (insurance != null)
            {
                insurance.Name = insuranceChanges.Name;
                insurance.Description = insuranceChanges.Description;
                insurance.Covering = insuranceChanges.Covering;
                insurance.ValidFrom = insuranceChanges.ValidFrom;
                insurance.CoverageTime = insuranceChanges.CoverageTime;
                insurance.Price = insuranceChanges.Price;
                insurance.RiskLevel = insuranceChanges.RiskLevel;
                insurance.ModifiedDate = DateTime.Now;

                return true;
            }

            return false;
        }
    }
}
