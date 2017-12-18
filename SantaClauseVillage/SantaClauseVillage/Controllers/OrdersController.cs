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
    public class OrdersController : Controller
    {
        // GET: SantaClaus
        public ActionResult OrdersList(bool? error)
        {
            if (Session["ID"] != null)
            {
                if (error == true)
                {
                    ModelState.AddModelError("", "Id not exist!");
                }
                SantaClauseVillageMongoDB db = new SantaClauseVillageMongoDB();
                var orders = db.GetAllOrders();
                if (orders != null)
                {
                    OrdersModels model = new OrdersModels();
                    model.EntityList = orders.ToList();
                    model.instanceDB = db;
                    return View(model);
                }
                else
                {
                    return View();
                }                
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult DetailsOrder(string id, bool? error)
        {
            if (Session["ID"] != null)
            {
                if (error == true)
                {
                    ModelState.AddModelError("", "Status Type not updated!");
                }
                SantaClauseVillageMongoDB db = new SantaClauseVillageMongoDB();
                var order = db.GetOrderById(id);
                if (order != null)
                {
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
                    return RedirectToAction("OrdersList", new { error = true });
                }                
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
            if (order != null)
            {
                result = db.UpdateOrder(new Order
                {
                    ID = id,
                    StatusType = statusType
                });
                if (result == true)
                {
                    return RedirectToAction("OrdersList", new { result = result });
                }
                else
                {
                    return RedirectToAction("DetailsOrder", new { error = true });
                }
            }
            else
            {
                return RedirectToAction("OrderList", new { error = true });
            }
        }
    }
}