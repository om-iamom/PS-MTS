
namespace PS.MedicalTrackingSystem.API.Settings.Repositories
{
   public interface IMedicineTrackingSystemDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string CollectionName { get; set; }
    }
}
