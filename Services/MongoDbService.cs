using MongoDB.Bson;
using MongoDB.Driver;
using mvc.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mvc.Services
{
    public class MongoDbService
    {
        private IMongoCollection<Team> TeamCollection { get; }
        private IMongoCollection<Office> OfficeCollection { get; }
        public MongoDbService(string databaseName,string collectionName,string databaseUrl)
        {
            var mongoClient = new MongoClient(databaseUrl);
            var mognoDatabase = mongoClient.GetDatabase(databaseName);
           TeamCollection = mognoDatabase.GetCollection<Team>(collectionName);
           OfficeCollection =  mognoDatabase.GetCollection<Office>(collectionName);
        }

        public async Task<List<Team>> GetAllTeam()
        {
            var team = new List<Team>();
            var allTeam = await TeamCollection.FindAsync(new BsonDocument());
            await allTeam.ForEachAsync(doc => team.Add(doc));
            return team;
        }

        public async Task<List<Office>> GetAllOffice(){
             var office = new List<Office>();
             var allOffice = await OfficeCollection.FindAsync(new BsonDocument());
             await allOffice.ForEachAsync(t => office.Add(t));
             return office;
        }
    }
}
