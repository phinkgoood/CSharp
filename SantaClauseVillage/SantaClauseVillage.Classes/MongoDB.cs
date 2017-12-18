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
            IEnumerable < Order > enumerOrders = orderCollection.Find(new BsonDocument()).SortBy(t => t.RequestDate).ToList();
            {
                if (enumerOrders != null)
                {
                    return enumerOrders;
                }
                else
                {
                    return null;
                }
            }
        }

        public IEnumerable<Toy> GetAllToys()
        {
            IMongoCollection<Toy> toyCollection = database.GetCollection<Toy>("toys");
            IEnumerable < Toy > enumerToys = toyCollection.Find(new BsonDocument()).ToList();
            if (enumerToys != null)
            {
                return enumerToys;
            }
            else
            {
                return null;
            }
            
        }

        public IEnumerable<User> GetAllUsers()
        {
            IMongoCollection<User> userCollection = database.GetCollection<User>("users");
            IEnumerable < User > enumerUsers = userCollection.Find(new BsonDocument()).ToList();
            if (enumerUsers != null)
            {
                return enumerUsers;
            }
            else
            {
                return null;
            }
        }

        public Order GetOrderById(string id)
        {
            IMongoCollection<Order> orderCollection = database.GetCollection<Order>("orders");
            try
            {
                if (id == null)
                {
                    throw new ArgumentNullException();
                }
                else if (id == "" || id == " ")
                {
                    throw new ArgumentException();
                }
                Order order = orderCollection.Find(_ => _.ID == id).FirstOrDefault();
                if (order != null)
                {
                    return order;
                }
                else
                {
                    return null;
                }
            }
            catch (ArgumentNullException)
            {
                return null;
            }
            catch (ArgumentException)
            {
                return null;
            }
            catch (FormatException)
            {
                return null;
            }
        }

        public Order GetOrderByKid(string kid)
        {
            IMongoCollection<Order> orderCollection = database.GetCollection<Order>("orders");
            try
            {
                if (kid == null)
                {
                    throw new ArgumentNullException();
                }
                else if (kid == "" || kid == " ")
                {
                    throw new ArgumentException();
                }
                Order order = orderCollection.Find(_ => _.Kid == kid).FirstOrDefault();
                if (order != null)
                {
                    return order;
                }
                else
                {
                    return null;
                }
            }
            catch (ArgumentNullException)
            {
                return null;
            }
            catch (ArgumentException)
            {
                return null;
            }
            catch (FormatException)
            {
                return null;
            }
        }

        public bool UpdateOrder(Order order)
        {
            {
                IMongoCollection<Order> orderCollection = database.GetCollection<Order>("orders");
                var filter = Builders<Order>.Filter.Eq("_id", ObjectId.Parse(order.ID));
                var update = Builders<Order>.Update
                    .Set("status", order.StatusType);                
                try
                {
                    if (order.ID == null)
                    {
                        throw new ArgumentNullException();
                    }
                    else if (order.ID == "" || order.ID ==" ")
                    {
                        throw new ArgumentException();
                    }
                    orderCollection.UpdateOne(filter, update);
                    return true;
                }
                catch (ArgumentNullException)
                {
                    return false;
                }
                catch (ArgumentException)
                {
                    return false;
                }
                catch (FormatException)
                {
                    return false;
                }
            }
        }

        public Toy GetToyById(string id)
        {
            IMongoCollection<Toy> toyCollection = database.GetCollection<Toy>("toys");
            try
            {
                if (id == null)
                {
                    throw new ArgumentNullException();
                }
                else if (id == "" || id == " ")
                {
                    throw new ArgumentException();
                }
                Toy toy = toyCollection.Find(_ => _.ID == id).FirstOrDefault();
                if (toy != null)
                {
                    return toy;
                }
                else
                {
                    return null;
                }
            }
            catch (ArgumentNullException)
            {
                return null;
            }
            catch (ArgumentException)
            {
                return null;
            }
            catch (FormatException)
            {
                return null;
            }
        }

        public Toy GetToyByName(string name)
        {
            IMongoCollection<Toy> toyCollection = database.GetCollection<Toy>("toys");
            try
            {
                if (name == null)
                {
                    throw new ArgumentNullException();
                }
                else if (name == "" || name == " ")
                {
                    throw new ArgumentException();
                }
                Toy toy = toyCollection.Find(_ => _.Name == name).FirstOrDefault();
                if (toy != null)
                {
                    return toy;
                }
                else
                {
                    return null;
                }
            }
            catch (ArgumentNullException)
            {
                return null;
            }
            catch (ArgumentException)
            {
                return null;
            }
            catch (FormatException)
            {
                return null;
            }
        }

        public User GetUserById(string id)
        {
            IMongoCollection<User> userCollection = database.GetCollection<User>("users");
            try
            {
                if (id == null)
                {
                    throw new ArgumentNullException();
                }
                else if (id == "" || id == " ")
                {
                    throw new ArgumentException();
                }
                User user = userCollection.Find(_ => _.ID == id).FirstOrDefault();
                if (user != null)
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
            catch (ArgumentNullException)
            {
                return null;
            }
            catch (ArgumentException)
            {
                return null;
            }
            catch (FormatException)
            {
                return null;
            }
        }

        public User GetUserByScreenname(string screenname)
        {
            IMongoCollection<User> userCollection = database.GetCollection<User>("users");
            try
            {
                if (screenname == null)
                {
                    throw new ArgumentNullException();
                }
                else if (screenname == "" || screenname == " ")
                {
                    throw new ArgumentException();
                }
                User user = userCollection.Find(_ => _.Screenname == screenname).FirstOrDefault();
                if (user != null)
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
            catch (ArgumentNullException)
            {
                return null;
            }
            catch (ArgumentException)
            {
                return null;
            }
            catch (FormatException)
            {
                return null;
            }
        }

        public User GetUserByEmail(string email)
        {
            IMongoCollection<User> userCollection = database.GetCollection<User>("users");
            try
            {
                if (email == null)
                {
                    throw new ArgumentNullException();
                }
                else if (email == "" || email == " ")
                {
                    throw new ArgumentException();
                }
                User user = userCollection.Find(_ => _.Email == email).FirstOrDefault();
                if (user != null)
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
            catch (ArgumentNullException)
            {
                return null;
            }
            catch (ArgumentException)
            {
                return null;
            }
            catch (FormatException)
            {
                return null;
            }
        }
    }
}
