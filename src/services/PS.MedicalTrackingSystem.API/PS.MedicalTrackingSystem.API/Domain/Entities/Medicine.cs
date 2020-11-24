using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PS.MedicalTrackingSystem.API.Domain.Entities
{
    public class Medicine
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Medicine Name")]
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public string ExpiryDate { get; set; }
        public string Notes { get; set; }
    }
}
