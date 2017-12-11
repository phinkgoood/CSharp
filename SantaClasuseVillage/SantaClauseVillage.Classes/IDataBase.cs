using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaClauseVillage.Classes
{
    interface IDataBase
    {
        Toy GetToyById(string id);
        Toy GetToyByName(string name);
        IEnumerable<Toy> GetAllToys();

        Order GetOrderById(string id);
        Order GetOrderByKid(string kid);
        IEnumerable<Order> GetAllOrders();

        User GetUserById(string id);
        Order GetUserByScreenname(string screenname);
        IEnumerable<User> GetAllUsers();

    }
}
