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
    /*  User GetUserById(string id);
        User GetUserByScreenname(string screenname);
        User GetUserByEmail(string email);
        IEnumerable<User> GetAllUsers();
    */
    [TestClass]
    public class Users
    {
        private IMongoDatabase db;
        private string userId = ObjectId.GenerateNewId().ToString();
        private const string USER_SCRENNAME = "user_screnname";
        private const string USER_EMAIL = "user_email";


        [TestInitialize]
        public void Initialize()
        {
            MongoClientSettings settings = new MongoClientSettings();
            MongoClient client = new MongoClient(MongoDBConfig.ConnectionString);
            db = client.GetDatabase(MongoDBConfig.DBName);
            IMongoCollection<User> collection = db.GetCollection<User>("users");
            User usertest = new User {ID=userId, Screenname=USER_SCRENNAME, Email=USER_EMAIL};
            collection.InsertOne(usertest);
        }

        [TestMethod]
        public void GetUserById_Should_Return_An_Object_User()
        {
            var db = new SantaClauseVillageDB();
            var user = db.GetUserById(userId);
            Assert.IsNotNull(user);
            Assert.IsInstanceOfType(user, typeof(User));
        }

        [TestMethod]
        public void GetUserByScreenname_Should_Return_An_Object_User()
        {
            var db = new SantaClauseVillageDB();
            var user = db.GetUserByScreenname(USER_SCRENNAME);
            Assert.IsNotNull(user);
            Assert.IsInstanceOfType(user, typeof(User));
        }

        [TestMethod]
        public void GetUserByEmail_Should_Return_An_Object_User()
        {
            var db = new SantaClauseVillageDB();
            var user = db.GetUserByEmail(USER_EMAIL);
            Assert.IsNotNull(user);
            Assert.IsInstanceOfType(user, typeof(User));
        }

        [TestMethod]
        public void GetAllUsers_Should_Return_A_List_Of_Users()
        {
            var db = new SantaClauseVillageDB();
            var usersList = db.GetAllUsers();
            Assert.AreEqual(1, usersList.Count());
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (db != null)
            {
                db.DropCollection("users");
            }
        }
    }
}
