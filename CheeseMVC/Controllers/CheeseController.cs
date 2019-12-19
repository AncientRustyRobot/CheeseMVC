using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        
        private static List<Cheese> Cheeses = new List<Cheese>();

        // GET: /<controller>/
        public IActionResult Index()
        {
            
            ViewBag.cheeses = Cheeses;

            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
        [Route("/Cheese/Add")]
        [HttpPost]
        public IActionResult NewCheese(string name, string description)
        {
            //Add new cheese to existing cheeses
            Cheese ch = new Cheese(name,description);
            Cheeses.Add(ch);
            return Redirect("/cheese");
        }
        /*[Route("/Cheese/Delete")]
        [HttpPost]*/
        public IActionResult Delete()
        {
            
            ViewBag.cheeses = Cheeses;
            return View();
        }
        [Route("/Cheese/Delete")]
        [HttpPost]
        public IActionResult Delete(string[] delete_cheese)
        {   foreach (string cheese in delete_cheese)
            {
                foreach(Cheese cheeseObj in Cheeses)
                {
                    if (cheese.Equals(cheeseObj.Name))
                    {
                        Cheeses.Remove(cheeseObj);
                        break;
                    }
                }
            }
            return Redirect("/cheese");
        }

       
    }
}
