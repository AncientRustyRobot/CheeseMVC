﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;
using CheeseMVC.Data;
using Microsoft.EntityFrameworkCore;

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {


        private CheeseDbContext context;

        public CheeseController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {

            IList<Cheese> cheeses = context.Cheeses.Include(c => c.Category).ToList();
            //List<Cheese> cheeses = context.Cheeses.ToList();


            return View(cheeses);
        }

        public IActionResult Add()
        {
            AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel(context.Categories.ToList());
            return View(addCheeseViewModel);
        }
        
        [HttpPost]
        public IActionResult Add(AddCheeseViewModel addCheeseViewModel)
        {
            if (ModelState.IsValid)
            {
                //Add new cheese to existing cheeses         
                //Cheese newCheese = addCheeseViewModel.CreateCheese();
                CheeseCategory newCheeseCategory =
                    context.Categories.Single(c => c.ID == addCheeseViewModel.CategoryID);
                Cheese newCheese = new Cheese()
                {
                    Name = addCheeseViewModel.Name,
                    Description = addCheeseViewModel.Description,
                    Rating = addCheeseViewModel.Rating,
                    Category = newCheeseCategory
                };
                context.Cheeses.Add(newCheese);
                context.SaveChanges();

                return Redirect("/cheese");
            }
                
            return View(addCheeseViewModel);
            

            //Cheeses.Add(new Cheese(name, description));
        }
        [Route("/Cheese/Delete")]
        
        public IActionResult Delete()
        {

            ViewBag.cheeses = context.Cheeses.ToList();
            return View();
        }


        [Route("/Cheese")]
        [Route("/Cheese/Index")]
        [Route("/Cheese/DeleteCheese")]
        [HttpPost]
        public IActionResult DeleteCheese(int[] cheeseIds)
        {   foreach(int cheeseId in cheeseIds)
            {
                Cheese theCheese = context.Cheeses.Single(c => c.ID == cheeseId);
                context.Cheeses.Remove(theCheese);
            }

            context.SaveChanges();
            
            return Redirect("/Cheese/Index");
        }

        public IActionResult Edit(int ID)
        {
            Cheese ch = context.Cheeses.Single(c => c.ID == ID);
            AddEditCheeseViewModel addEditCheeseViewModel = new AddEditCheeseViewModel(ch, context.Categories.ToList());
            
            return View(addEditCheeseViewModel);
        }
        
        [Route("/Cheese/Edit")]
        [HttpPost]
        public IActionResult Edit(AddEditCheeseViewModel addEditCheeseViewModel)
        {
            if (ModelState.IsValid)
            {
                Cheese ch = context.Cheeses.Single(c => c.ID == addEditCheeseViewModel.ID);
                ch.Name = addEditCheeseViewModel.Name;
                ch.Description = addEditCheeseViewModel.Description;
                ch.Category= context.Categories.Single(c => c.ID == addEditCheeseViewModel.CategoryID);
                ch.Rating = addEditCheeseViewModel.Rating;

                context.SaveChanges();

                return Redirect("/Cheese/Index");
            }

            return View(addEditCheeseViewModel);
            
        }

    }
}
//