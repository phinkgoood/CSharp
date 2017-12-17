using SantaClauseVillage.Classes;
using SantaClauseVillage.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SantaClauseVillageMongoDB = SantaClauseVillage.Classes.MongoDB;

namespace SantaClauseVillage.Controllers
{
    public class SantaClausController : Controller
    {
        // GET: SantaClaus
        public ActionResult OrdersList()
        {
            if (Session["ID"] != null)
            {
                SantaClauseVillageMongoDB db = new SantaClauseVillageMongoDB();
                var orders = db.GetAllOrders();
                OrdersModels model = new OrdersModels();
                model.EntityList = orders.ToList();
                model.instanceDB = db;
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult DetailsOrder(string id)
        {
            if (Session["ID"] != null)
            {
                SantaClauseVillageMongoDB db = new SantaClauseVillageMongoDB();
                var order = db.GetOrderById(id);
                Order model = new Order();
                model.ID = order.ID;
                model.Kid = order.Kid;
                model.StatusType = order.StatusType;
                List<Toy> ToysModel = new List<Toy>();
                for (int i = 0; i < order.Toys.Count; i++)
                {
                    ToysModel.Add(db.GetToyByName(order.Toys[i].Name));
                }
                model.RequestDate = order.RequestDate;
                model.Toys = ToysModel;
                return View(model);
            }

            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult SaveOrder(string id, StatusType statusType)
        {
            bool result;
            SantaClauseVillageMongoDB db = new SantaClauseVillageMongoDB();
            Order order = db.GetOrderById(id);
            result = db.UpdateOrder(new Order
            {
                ID = id,
                StatusType = statusType
            });
            return RedirectToAction("OrdersList", new { result = result });
        }
    }
}