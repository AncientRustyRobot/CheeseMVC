using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;
    



namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        
        

        // GET: /<controller>/
        public IActionResult Index()
        {
            
            List<Cheese> cheeses = CheeseData.GetAll();
            

            return View(cheeses);
        }

        public IActionResult Add()
        {
            AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel();
            return View(addCheeseViewModel);
        }
        
        [HttpPost]
        public IActionResult Add(AddCheeseViewModel addCheeseViewModel)
        {
            if (ModelState.IsValid)
            {
                //Add new cheese to existing cheeses         
                Cheese newCheese = addCheeseViewModel.CreateCheese();
                CheeseData.Add(newCheese);
                return Redirect("/cheese");
            }
                
            return View(addCheeseViewModel);
            

            /*Cheeses.Add(new Cheese(name, description));*/
        }
        [Route("/Cheese/Delete")]
        
        public IActionResult Delete()
        {

            ViewBag.cheeses = CheeseData.GetAll();
            return View();
        }


        [Route("/Cheese")]
        [Route("/Cheese/Index")]
        [Route("/Cheese/DeleteCheese")]
        [HttpPost]
        public IActionResult DeleteCheese(int[] cheeseIds)
        {   foreach(int cheeseId in cheeseIds)
            {
                CheeseData.Remove(cheeseId);
            }
            
            return Redirect("/Cheese/Index");
        }

        public IActionResult Edit(int cheeseId)
        {
            Cheese ch = CheeseData.GetById(cheeseId);
            AddEditCheeseViewModel addEditCheeseViewModel = new AddEditCheeseViewModel(ch);
            
            return View(addEditCheeseViewModel);
        }
        
        [Route("/Cheese/Edit")]
        [HttpPost]
        public IActionResult Edit(AddEditCheeseViewModel addEditCheeseViewModel)
        {
            if (ModelState.IsValid)
            {
                Cheese ch = CheeseData.GetById(addEditCheeseViewModel.CheeseId);
                ch.Name = addEditCheeseViewModel.Name;
                ch.Description = addEditCheeseViewModel.Description;
                ch.Type = addEditCheeseViewModel.Type;
                ch.Rating = addEditCheeseViewModel.Rating;
                

                return Redirect("/Cheese/Index");
            }

            return View(addEditCheeseViewModel);
            
        }

    }
}
