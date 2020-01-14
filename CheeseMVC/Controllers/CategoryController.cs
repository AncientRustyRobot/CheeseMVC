using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheeseMVC.Data;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;


namespace CheeseMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CheeseDbContext context;

        public CategoryController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index()
        {
            return View(context.Categories.ToList());
        }

        public IActionResult Add()
        {
            AddCategoryViewModel cat = new AddCategoryViewModel();
            return View(cat);
        }

        [HttpPost]
        public IActionResult Add(AddCategoryViewModel vm)
        {
            if (ModelState.IsValid)
            {
                //Add new cheese to existing cheeses         
                CheeseCategory newCat = new CheeseCategory
                {
                    Name = vm.Name
                };
                context.Categories.Add(newCat);
                context.SaveChanges();

                return Redirect("Index");
            }

            return View(vm);
        }
    }
}
//