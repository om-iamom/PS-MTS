using MongoDB.Driver;
using PS.MedicalTrackingSystem.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PS.MedicalTrackingSystem.API.DataAccess
{
    public class MedicinContextSeed
    {
        public static void SeedData(IMongoCollection<Medicine> medicineCollection)
        {
            bool isMedicineExists = medicineCollection.Find(p => true).Any();

            if (!isMedicineExists)
                medicineCollection.InsertManyAsync(GetPreConfigureProducts());
        }

        private static IEnumerable<Medicine> GetPreConfigureProducts()
        {
            return new List<Medicine>()
            {
                 new Medicine()
                {
                    Name="Paracetamol",
                    Brand="ManKind",
                    Price=32.09M,
                    Quantity=10,
                    ExpiryDate="2022/10/10",
                    Notes="This is good for fever"

                },
                  new Medicine()
                {
                    Name="Crocin",
                    Brand="Pfizer",
                    Price=102.00M,
                    Quantity=20,
                    ExpiryDate="2021/10/10",
                    Notes="This is good for fever and running nose"

                }

            };
        }
    }
}
