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

        //methods haven't been implemented yet
        public IEnumerable<Order> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Toy> GetAllToys()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Order GetOrderById(string id)
        {
            throw new NotImplementedException();
        }

        public Order GetOrderByKid(string kid)
        {
            throw new NotImplementedException();
        }

        public Toy GetToyById(string id)
        {
            throw new NotImplementedException();
        }

        public Toy GetToyByName(string name)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(string id)
        {
            throw new NotImplementedException();
        }

        public Order GetUserByScreenname(string screenname)
        {
            throw new NotImplementedException();
        }
    }
}
