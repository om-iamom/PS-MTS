using MongoDB.Driver;
using PS.MedicalTrackingSystem.API.Business.Repositories;
using PS.MedicalTrackingSystem.API.DataAccess.Repositories;
using PS.MedicalTrackingSystem.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PS.MedicalTrackingSystem.API.Business.Services
{
    public class MedicineBusiness : IMedicineBusiness
    {
        private readonly IMedicineContext _medicineContext;

        public MedicineBusiness(IMedicineContext medicineContext)
        {
            _medicineContext = medicineContext ?? throw new ArgumentNullException(nameof(medicineContext));
        }

        public async Task<IEnumerable<Medicine>> GetAllMedicines()
        {
            return await _medicineContext
                            .Medicines
                            .Find(m => true)
                            .ToListAsync();
        }

        public async Task<Medicine> GetMedicineDetails(string id)
        {
            return await _medicineContext
                            .Medicines
                            .Find(m => m.Id == id)
                            .FirstOrDefaultAsync();
        }

        public async Task<Medicine> GetMedicineByName(string name)
        {
            FilterDefinition<Medicine> filter = Builders<Medicine>.Filter.ElemMatch(m => m.Name, name);

            return await _medicineContext
                            .Medicines
                            .Find(filter)
                            .FirstOrDefaultAsync();
        }

        public async Task Create(Medicine medicine)
        {
            await _medicineContext.Medicines.InsertOneAsync(medicine);
        }  

       

        public async Task<bool> Update(Medicine medicine)
        {
            FilterDefinition<Medicine> filter = Builders<Medicine>.Filter.Eq(p => p.Id, medicine.Id);
            var updateResult = await _medicineContext.Medicines.ReplaceOneAsync(filter, medicine);

            return (updateResult.IsAcknowledged && updateResult.ModifiedCount > 0);

        }

      
    }
}
