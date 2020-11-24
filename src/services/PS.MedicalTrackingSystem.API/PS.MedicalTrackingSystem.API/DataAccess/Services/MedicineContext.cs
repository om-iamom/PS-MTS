using MongoDB.Driver;
using PS.MedicalTrackingSystem.API.DataAccess.Repositories;
using PS.MedicalTrackingSystem.API.Domain.Entities;
using PS.MedicalTrackingSystem.API.Settings.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PS.MedicalTrackingSystem.API.DataAccess.Services
{
    public class MedicineContext : IMedicineContext
    {
        public MedicineContext(IMedicineTrackingSystemDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            Medicines = database.GetCollection<Medicine>(settings.CollectionName);
            MedicinContextSeed.SeedData(Medicines);

        }
              

        public IMongoCollection<Medicine> Medicines { get; }
    }
}
