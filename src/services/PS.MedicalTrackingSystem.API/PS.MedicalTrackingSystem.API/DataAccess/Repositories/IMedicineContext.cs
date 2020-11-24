using MongoDB.Driver;
using PS.MedicalTrackingSystem.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PS.MedicalTrackingSystem.API.DataAccess.Repositories
{
   public interface IMedicineContext
    {
        IMongoCollection<Medicine> Medicines { get; }
    }
}
