using SantaClauseVillage.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SantaClauseVillageMongoDB = SantaClauseVillage.Classes.MongoDB;

namespace SantaClauseVillage.Models
{
    public class OrdersModels
    {
        public List<Order> EntityList { get; set; }
        public SantaClauseVillageMongoDB instanceDB;

        public decimal GetTotalPrice(List<Toy> toysList)
        {
            decimal totalCost = 0;
            foreach (Toy toy in toysList)
            {
                if (instanceDB.GetToyByName(toy.Name) != null)
                {
                    totalCost += instanceDB.GetToyByName(toy.Name).Cost;
                }
                else
                {
                    totalCost = 1000000000;
                }                
            }
            return totalCost;
        }
    }
}