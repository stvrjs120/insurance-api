using InsuranceAPI.Models;
using System.Collections.Generic;

namespace InsuranceAPI.Interfaces
{
    public interface IInsuranceService
    {
        Insurance Create(Insurance insurance);
        Insurance Read(int id);
        bool Update(Insurance insuranceChanges);
        bool Delete(int id);
        IEnumerable<Insurance> List();
    }
}
