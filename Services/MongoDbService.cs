using MongoDB.Bson;
using MongoDB.Driver;
using mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Services
{
    public class MongoDbService
    {
        private IMongoCollection<Team> TeamCollection { get; }
        public MongoDbService(string databaseName,string collectionName,string databaseUrl)
        {
            var mongoClient = new MongoClient(databaseUrl);
            var mognoDatabase = mongoClient.GetDatabase(databaseName);
           TeamCollection = mognoDatabase.GetCollection<Team>(collectionName);
        }

        public async Task<List<Team>> GetAllTeam()
        {
            var team = new List<Team>();
            var allTeam = await TeamCollection.FindAsync(new BsonDocument());
            await allTeam.ForEachAsync(doc => team.Add(doc));
            return team;
        }
    }
}
