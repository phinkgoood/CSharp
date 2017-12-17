using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaClauseVillage.Classes
{
    public interface IDataBase
    {
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

    }
}
