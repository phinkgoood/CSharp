using Microsoft.VisualStudio.TestTools.UnitTesting;
using SantaClauseVillage.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaClauseVillage.Test
{
    [TestClass]
    public class MongoDBConfigTest
    {
        public MongoDBConfigTest()
        {}

        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void DBName_Should_Have_Value()
        {
            Assert.AreEqual("DBName", MongoDBConfig.DBName);
        }

        [TestMethod]
        public void Username_Should_Have_Value()
        {
            Assert.AreEqual("Username", MongoDBConfig.Username);
        }

        [TestMethod]
        public void Password_Should_Have_Value()
        {
            Assert.AreEqual("Password", MongoDBConfig.Password);
        }

        [TestMethod]
        public void Host_Should_Have_Value()
        {
            Assert.AreEqual("Host", MongoDBConfig.Host);
        }

        [TestMethod]
        public void Port_Should_Have_Value()
        {
            Assert.AreEqual(13000, MongoDBConfig.Port);
        }

    }
}
