using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SantaClauseVillage.Classes;

namespace SantaClauseVillage.Test.Mocks
{
    class DatabaseMock : IDataBase

    {
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

        public User GetUserByScreenname(string screenname)
        {
            throw new NotImplementedException();
        }

        public bool UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
