using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace mvc.Models
{
    public class Office
    {
        [BsonId]
        public ObjectId _id { get; set; }
        public string office { get; set; }
    }
}