using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace SantaClauseVillage.Test.Mocks
{
    public class MongoConnectionMock
    {
        public string DBName { get; set; }
        public IMongoDatabase GetDatabase()
        {
            MongoClientSettings settings = new MongoClientSettings();

            // settings.Credentials
            MongoClient client = new MongoClient();
            IMongoDatabase db = client.GetDatabase(DBName);
            return db;
        }
    }
}
