using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaClauseVillage.Classes
{
    public class MongoDB : IDataBase
    {
        private IMongoDatabase database
        {
            get
            {
                return MongoConnection.Instance.Database;
            }
        }

        public IEnumerable<Order> GetAllOrders()
        {
            IMongoCollection<Order> orderCollection = database.GetCollection<Order>("orders");
            return orderCollection.Find(new BsonDocument()).SortBy(t => t.RequestDate).ToList();
        }

        public IEnumerable<Toy> GetAllToys()
        {
            IMongoCollection<Toy> toyCollection = database.GetCollection<Toy>("toys");
            return toyCollection.Find(new BsonDocument()).ToList();
        }

        public IEnumerable<User> GetAllUsers()
        {
            IMongoCollection<User> userCollection = database.GetCollection<User>("users");
            return userCollection.Find(new BsonDocument()).ToList();
        }

        public Order GetOrderById(string id)
        {
            IMongoCollection<Order> orderCollection = database.GetCollection<Order>("orders");
            return orderCollection.Find(_=>_.ID == id).FirstOrDefault();
        }

        public Order GetOrderByKid(string kid)
        {
            IMongoCollection<Order> orderCollection = database.GetCollection<Order>("orders");
            return orderCollection.Find(_ => _.Kid == kid).FirstOrDefault();
        }

        public bool UpdateOrder(Order order)
        {
            {
                IMongoCollection<Order> orderCollection = database.GetCollection<Order>("orders");
                var filter = Builders<Order>.Filter.Eq("_id", ObjectId.Parse(order.ID));
                var update = Builders<Order>.Update
                    .Set("status", order.StatusType);
                if (order.ID == null)
                {
                    throw new ArgumentNullException();
                }
                try
                {
                    orderCollection.UpdateOne(filter, update);
                    return true;
                }
                catch (ArgumentNullException)
                {
                    return false;
                }
            }
        }

        public Toy GetToyById(string id)
        {
            IMongoCollection<Toy> toyCollection = database.GetCollection<Toy>("toys");
            return toyCollection.Find(_ => _.ID == id).FirstOrDefault();
        }

        public Toy GetToyByName(string name)
        {
            IMongoCollection<Toy> toyCollection = database.GetCollection<Toy>("toys");
            return toyCollection.Find(_ => _.Name == name).FirstOrDefault();
        }

        public User GetUserById(string id)
        {
            IMongoCollection<User> userCollection = database.GetCollection<User>("users");
            return userCollection.Find(_ => _.ID == id).FirstOrDefault();
        }

        public User GetUserByScreenname(string screenname)
        {
            IMongoCollection<User> userCollection = database.GetCollection<User>("users");
            return userCollection.Find(_ => _.Screenname == screenname).FirstOrDefault();
        }

        public User GetUserByEmail(string email)
        {
            IMongoCollection<User> userCollection = database.GetCollection<User>("users");
            return userCollection.Find(_ => _.Email == email).FirstOrDefault();
        }
    }
}
