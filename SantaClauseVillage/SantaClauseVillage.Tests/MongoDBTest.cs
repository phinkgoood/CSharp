using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SantaClauseVillage.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaClauseVillage.Tests
{
    [TestClass]
    public class IDataBaseTest
    {
        [TestMethod]
        public void GetToyById_Should_Return_A_Toy()
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.GetToyById(It.IsAny<string>())).Returns(new Toy());
            var result = mock.Object.GetToyById("id");

            Assert.IsInstanceOfType(result, typeof(Toy));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetToyById_Should_Throw_Exception_When_Id_Is_Null() /* Is_Null */
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.GetToyById(It.Is<string>(id => string.IsNullOrEmpty(id) == true))).Throws<ArgumentNullException>();
            var result = mock.Object.GetToyById(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetToyById_Should_Throw_Exception_When_Id_Is_Empty() /* Is_Empty "" */
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.GetToyById(It.Is<string>(id => string.IsNullOrEmpty(id) == true))).Throws<ArgumentException>();
            var result = mock.Object.GetToyById("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetToyById_Should_Throw_Exception_When_Id_Is_White_Space() /* IsWhiteSpace " " */
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.GetToyById(It.Is<string>(id => string.IsNullOrWhiteSpace(id) == true))).Throws<ArgumentException>();
            var result = mock.Object.GetToyById(" ");
        }

        [TestMethod]
        public void GetToyByName_Should_Return_A_Toy()
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.GetToyByName(It.IsAny<string>())).Returns(new Toy());
            var result = mock.Object.GetToyByName("name");

            Assert.IsInstanceOfType(result, typeof(Toy));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetToyByName_Should_Throw_Exception_When_Name_Is_Null() /* Is_Null */
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.GetToyByName(It.Is<string>(name => string.IsNullOrEmpty(name) == true))).Throws<ArgumentNullException>();
            var result = mock.Object.GetToyByName(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetToyByName_Should_Throw_Exception_When_Name_Is_Empty() /* Is_Empty "" */
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.GetToyByName(It.Is<string>(name => string.IsNullOrEmpty(name) == true))).Throws<ArgumentException>();
            var result = mock.Object.GetToyByName("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetToyByName_Should_Throw_Exception_When_Name_Is_White_Space() /* IsWhiteSpace " " */
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.GetToyByName(It.Is<string>(name => string.IsNullOrWhiteSpace(name) == true))).Throws<ArgumentException>();
            var result = mock.Object.GetToyByName(" ");
        }

        [TestMethod]
        public void GetAllToys_Should_Return_An_IEnumerable_Of_Toy()
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.GetAllToys()).Returns(new List<Toy>());
            var result = mock.Object.GetAllToys();

            Assert.IsInstanceOfType(result, typeof(IEnumerable<Toy>));

        }

        [TestMethod]
        public void GetOrderById_Should_Return_A_Order()
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.GetOrderById(It.IsAny<string>())).Returns(new Order());
            var result = mock.Object.GetOrderById("id");

            Assert.IsInstanceOfType(result, typeof(Order));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetOrderById_Should_Throw_Exception_When_Id_Is_Null() /* Is_Null */
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.GetOrderById(It.Is<string>(id => string.IsNullOrEmpty(id) == true))).Throws<ArgumentNullException>();
            var result = mock.Object.GetOrderById(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetOrderById_Should_Throw_Exception_When_Id_Is_Empty() /* Is_Empty "" */
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.GetOrderById(It.Is<string>(id => string.IsNullOrEmpty(id) == true))).Throws<ArgumentException>();
            var result = mock.Object.GetOrderById("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetOrderById_Should_Throw_Exception_When_Id_Is_White_Space() /* IsWhiteSpace " " */
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.GetOrderById(It.Is<string>(id => string.IsNullOrWhiteSpace(id) == true))).Throws<ArgumentException>();
            var result = mock.Object.GetOrderById(" ");
        }

        [TestMethod]
        public void GetOrderByKid_Should_Return_A_Order()
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.GetOrderByKid(It.IsAny<string>())).Returns(new Order());
            var result = mock.Object.GetOrderByKid("kid");

            Assert.IsInstanceOfType(result, typeof(Order));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetOrderByKid_Should_Throw_Exception_When_Kid_Is_Null() /* Is_Null */
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.GetOrderByKid(It.Is<string>(kid => string.IsNullOrEmpty(kid) == true))).Throws<ArgumentNullException>();
            var result = mock.Object.GetOrderByKid(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetOrderByKid_Should_Throw_Exception_When_Kid_Is_Empty() /* Is_Empty "" */
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.GetOrderByKid(It.Is<string>(kid => string.IsNullOrEmpty(kid) == true))).Throws<ArgumentException>();
            var result = mock.Object.GetOrderByKid("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetOrderByKid_Should_Throw_Exception_When_Kid_Is_White_Space() /* IsWhiteSpace " " */
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.GetOrderByKid(It.Is<string>(kid => string.IsNullOrWhiteSpace(kid) == true))).Throws<ArgumentException>();
            var result = mock.Object.GetOrderByKid(" ");
        }

        [TestMethod]
        public void Update_Order_Should_Return_True()
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            var order = new Order { ID = "id", StatusType = (StatusType)2 };
            mock.Setup(m => m.UpdateOrder(It.IsAny<Order>())).Returns(true);
            var result = mock.Object.UpdateOrder(order);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Update_Order_Should_Throw_Exception_When_Id_Is_Null()
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            var order = new Order { StatusType = (StatusType)2 };
            mock.Setup(m => m.UpdateOrder(It.Is<Order>(Order => string.IsNullOrEmpty(Order.ID)))).Throws<ArgumentNullException>();
            var result = mock.Object.UpdateOrder(order);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Update_Order_Should_Throw_Exception_When_Id_Is_Empty()
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            var order = new Order {ID="", StatusType = (StatusType)2 };
            mock.Setup(m => m.UpdateOrder(It.Is<Order>(Order => string.IsNullOrEmpty(Order.ID)))).Throws<ArgumentException>();
            var result = mock.Object.UpdateOrder(order);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Update_Order_Should_Throw_Exception_When_Id_Is_White_Space()
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            var order = new Order { ID = " ", StatusType = (StatusType)2 };
            mock.Setup(m => m.UpdateOrder(It.Is<Order>(Order => string.IsNullOrWhiteSpace(Order.ID)))).Throws<ArgumentException>();
            var result = mock.Object.UpdateOrder(order);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Update_Order_Should_Throw_Exception_When_Status_Is_Out_Of_Range()
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            var order = new Order { ID = " ", StatusType = (StatusType)3 };
            mock.Setup(m => m.UpdateOrder(It.Is<Order>(Order => (int)Order.StatusType < 0 || (int)Order.StatusType > (Enum.GetValues(typeof(StatusType)).Length)-1))).Throws<ArgumentOutOfRangeException>();
            var result = mock.Object.UpdateOrder(order);
        }


        [TestMethod]
        public void GetAllOrders_Should_Return_An_IEnumerable_Of_Order()
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.GetAllOrders()).Returns(new List<Order>());
            var result = mock.Object.GetAllOrders();

            Assert.IsInstanceOfType(result, typeof(IEnumerable<Order>));
        }

        [TestMethod]
        public void GetUserById_Should_Return_A_User()
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.GetUserById(It.IsAny<string>())).Returns(new User());
            var result = mock.Object.GetUserById("id");

            Assert.IsInstanceOfType(result, typeof(User));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetUserById_Should_Throw_Exception_When_Id_Is_Null() /* Is_Null */
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.GetUserById(It.Is<string>(id => string.IsNullOrEmpty(id) == true))).Throws<ArgumentNullException>();
            var result = mock.Object.GetUserById(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetUserById_Should_Throw_Exception_When_Id_Is_Empty() /* Is_Empty "" */
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.GetUserById(It.Is<string>(id => string.IsNullOrEmpty(id) == true))).Throws<ArgumentException>();
            var result = mock.Object.GetUserById("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetUserById_Should_Throw_Exception_When_Id_Is_White_Space() /* IsWhiteSpace " " */
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.GetUserById(It.Is<string>(id => string.IsNullOrWhiteSpace(id) == true))).Throws<ArgumentException>();
            var result = mock.Object.GetUserById(" ");
        }

        [TestMethod]
        public void GetUserByScreenname_Should_Return_A_User()
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.GetUserByScreenname(It.IsAny<string>())).Returns(new User());
            var result = mock.Object.GetUserByScreenname("screanname");

            Assert.IsInstanceOfType(result, typeof(User));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetUserByScreenname_Should_Throw_Exception_When_Screenname_Is_Null() /* Is_Null */
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.GetUserByScreenname(It.Is<string>(screanname => string.IsNullOrEmpty(screanname) == true))).Throws<ArgumentNullException>();
            var result = mock.Object.GetUserByScreenname(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetUserByScreenname_Should_Throw_Exception_When_Screenname_Is_Empty() /* Is_Empty "" */
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.GetUserByScreenname(It.Is<string>(screanname => string.IsNullOrEmpty(screanname) == true))).Throws<ArgumentException>();
            var result = mock.Object.GetUserByScreenname("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetUserByScreenname_Should_Throw_Exception_When_Screenname_Is_White_Space() /* IsWhiteSpace " " */
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.GetUserByScreenname(It.Is<string>(screanname => string.IsNullOrWhiteSpace(screanname) == true))).Throws<ArgumentException>();
            var result = mock.Object.GetUserByScreenname(" ");
        }

        [TestMethod]
        public void GetUserByEmail_Should_Return_A_User()
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.GetUserByEmail(It.IsAny<string>())).Returns(new User());
            var result = mock.Object.GetUserByEmail("email");

            Assert.IsInstanceOfType(result, typeof(User));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetUserByEmail_Should_Throw_Exception_When_Email_Is_Null() /* Is_Null */
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.GetUserByEmail(It.Is<string>(email => string.IsNullOrEmpty(email) == true))).Throws<ArgumentNullException>();
            var result = mock.Object.GetUserByEmail(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetUserByEmail_Should_Throw_Exception_When_Email_Is_Empty() /* Is_Empty "" */
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.GetUserByEmail(It.Is<string>(email => string.IsNullOrEmpty(email) == true))).Throws<ArgumentException>();
            var result = mock.Object.GetUserByEmail("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetUserByEmail_Should_Throw_Exception_When_Email_Is_White_Space() /* IsWhiteSpace " " */
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.GetUserByEmail(It.Is<string>(email => string.IsNullOrWhiteSpace(email) == true))).Throws<ArgumentException>();
            var result = mock.Object.GetUserByEmail(" ");
        }

        [TestMethod]
        public void GetAllUsers_Should_Return_An_IEnumerable_Of_User()
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.GetAllUsers()).Returns(new List<User>());
            var result = mock.Object.GetAllUsers();

            Assert.IsInstanceOfType(result, typeof(IEnumerable<User>));

        }
    }
}
