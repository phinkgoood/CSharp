using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Driver;
using SantaClauseVillage.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SantaClauseVillageDB = SantaClauseVillage.Classes.MongoDB;

namespace SantaClauseVillage.Tests.Integration
{
    /*
        Toy GetToyById(string id);
        Toy GetToyByName(string name);
        IEnumerable<Toy> GetAllToys();

        Order GetOrderById(string id);
        Order GetOrderByKid(string kid);
        bool UpdateOrder(Order order);
        IEnumerable<Order> GetAllOrders();

        User GetUserById(string id);
        User GetUserByScreenname(string screenname);
        User GetUserByEmail(string email);
        IEnumerable<User> GetAllUsers();
    */

    [TestClass]
    public class Toys
    {
        private IMongoDatabase db;
        private string toyId = ObjectId.GenerateNewId().ToString();
        private const string TOY_NAME = "toy_name";

        [TestInitialize]
        public void Initialize()
        {
            MongoClientSettings settings = new MongoClientSettings();
            MongoClient client = new MongoClient(MongoDBConfig.ConnectionString);
            db = client.GetDatabase(MongoDBConfig.DBName);
            IMongoCollection<Toy> collection = db.GetCollection<Toy>("toys");
            Toy toytest = new Toy { ID = toyId, Name = TOY_NAME};
            collection.InsertOne(toytest);
        }
        
        [TestMethod]
        public void GetToyById_Should_Return_An_Object_Toy()
        {
            var db = new SantaClauseVillageDB();
            var toy = db.GetToyById(toyId);
            Assert.IsNotNull(toy);
            Assert.IsInstanceOfType(toy, typeof(Toy));
        }

        [TestMethod]
        public void GetToyByName_Should_Return_An_Object_Toy()
        {
            var db = new SantaClauseVillageDB();
            var toy = db.GetToyByName(TOY_NAME);
            Assert.IsNotNull(toy);
            Assert.IsInstanceOfType(toy, typeof(Toy));
        }

        [TestMethod]
        public void GetAllToys_Should_Return_A_List_Of_Toys()
        {
            var db = new SantaClauseVillageDB();
            var toysList = db.GetAllToys();
            Assert.AreEqual(1, toysList.Count());
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (db != null)
            {
                db.DropCollection("toys");
            }
        }
    }
}
