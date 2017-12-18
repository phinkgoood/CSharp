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
    [TestClass]
    public class Orders
    {
        private IMongoDatabase db;
        private string orderId = ObjectId.GenerateNewId().ToString();
        private const string ORDER_KID = "order_kid";

        [TestInitialize]
        public void Initialize()
        {
            MongoClientSettings settings = new MongoClientSettings();
            MongoClient client = new MongoClient(MongoDBConfig.ConnectionString);
            db = client.GetDatabase(MongoDBConfig.DBName);
            IMongoCollection<Order> collection = db.GetCollection<Order>("orders");
            Order usertest = new Order { ID = orderId, Kid = ORDER_KID };
            collection.InsertOne(usertest);
        }

        [TestMethod]
        public void GetOrderById_Should_Return_An_Object_Order()
        {
            var db = new SantaClauseVillageDB();
            var order = db.GetOrderById(orderId);
            Assert.IsNotNull(order);
            Assert.IsInstanceOfType(order, typeof(Order));
        }

        [TestMethod]
        public void GetOrderByKid_Should_Return_An_Object_Order()
        {
            var db = new SantaClauseVillageDB();
            var order = db.GetOrderByKid(ORDER_KID);
            Assert.IsNotNull(order);
            Assert.IsInstanceOfType(order, typeof(Order));
        }

        [TestMethod]
        public void UpdateOrder_Should_Return_True()
        {
            var db = new SantaClauseVillageDB();
            var order = db.GetOrderById(orderId);
            order.StatusType = StatusType.ReadyToSent;
            Assert.IsTrue(db.UpdateOrder(order));
        }

        [TestMethod]
        public void GetAllOrders_Should_Return_A_List_Of_Orders()
        {
            var db = new SantaClauseVillageDB();
            var ordersList = db.GetAllOrders();
            Assert.AreEqual(1, ordersList.Count());
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (db != null)
            {
                db.DropCollection("orders");
            }
        }
    }
}
