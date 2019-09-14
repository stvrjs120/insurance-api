using System.Collections.Generic;
using InsuranceAPI.Interfaces;
using InsuranceAPI.Models;
using InsuranceAPI.Models.Context;

namespace InsuranceAPI.Repositories
{
    public class SQLInsuranceRepository : IInsuranceRepository
    {
        private readonly ApplicationDBContext context;

        public SQLInsuranceRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

        public Insurance Create(Insurance insurance)
        {
            context.Insurance.Add(insurance);
            context.SaveChanges();
            return insurance;
        }

        public bool Delete(int id)
        {
            Insurance insurance = context.Insurance.Find(id);
            if (insurance != null)
            {
                context.Insurance.Remove(insurance);
                context.SaveChanges();

                return true;
            }

            return false;
        }

        public IEnumerable<Insurance> List()
        {
            return context.Insurance;
        }

        public Insurance Read(int id)
        {
            return context.Insurance.Find(id);
        }

        public bool Update(Insurance insuranceChanges)
        {
            var insurance = context.Insurance.Attach(insuranceChanges);

            if (insurance != null)
            {
                insurance.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
