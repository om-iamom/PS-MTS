using PS.MedicalTrackingSystem.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PS.MedicalTrackingSystem.API.Business.Repositories
{
    public interface IMedicineBusiness
    {
        Task<IEnumerable<Medicine>> GetAllMedicines();
        Task<Medicine> GetMedicineDetails(string id);
        Task<Medicine> GetMedicineByName(string name);
        Task Create(Medicine medicine);
        Task<bool> Update(Medicine medicine);
    }
}
