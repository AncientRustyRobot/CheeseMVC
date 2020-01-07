using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models
{
    public class CheeseData
    {
       static private List<Cheese> Cheeses = new List<Cheese>();

        //GetAll
        public static List<Cheese> GetAll()
        {
            return Cheeses;
        }

        //Add
        public static void Add(Cheese newCheese)
        {
            Cheeses.Add(newCheese);
        }


        //Remove
        public static void Remove(int id)
        {
            Cheese cheeseToRemove = GetById(id);
            Cheeses.Remove(cheeseToRemove);

        }

        //GetById
        public static Cheese GetById(int id)
        {
            return Cheeses.Single(p => p.CheeseId == id);
        }
    }
}
