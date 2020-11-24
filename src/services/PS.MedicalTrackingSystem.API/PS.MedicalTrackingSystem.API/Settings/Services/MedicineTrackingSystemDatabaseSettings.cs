using PS.MedicalTrackingSystem.API.Settings.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PS.MedicalTrackingSystem.API.Settings.Services
{
    public class MedicineTrackingSystemDatabaseSettings : IMedicineTrackingSystemDatabaseSettings
    {
        public string ConnectionString { get ; set; }
        public string DatabaseName { get ; set ; }
        public string CollectionName { get ; set ; }
    }
}
