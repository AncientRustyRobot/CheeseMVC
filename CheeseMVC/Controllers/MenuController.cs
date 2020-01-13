using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheeseMVC.Data;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CheeseMVC.Controllers
{
    public class MenuController : Controller
    {
        private readonly CheeseDbContext context;

        public MenuController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            IList<Menu> menus = context.Menus.ToList();

            return View(menus);
            
        }

        public IActionResult Add()
        {
            AddMenuViewModel men = new AddMenuViewModel();
            return View(men);
        }

        [HttpPost]
        public IActionResult Add(AddMenuViewModel vm)
        {
            if (ModelState.IsValid)
            {
                //Add new menu to existing menus         
                Menu newMenu = new Menu
                {
                    Name = vm.Name
                };
                context.Menus.Add(newMenu);
                context.SaveChanges();

                return Redirect("/Menu/ViewMenu/" + newMenu.ID);
            }

            return View(vm);
        }


        public IActionResult ViewMenu(int id)
        {
            Menu men = context.Menus.Single(c => c.ID == id);
            List<CheeseMenu> items = context
                                    .CheeseMenus
                                    .Include(item => item.Cheese)
                                    .Where(cm => cm.MenuID == id)
                                    .ToList();
            ViewMenuViewModel viewMenu = new ViewMenuViewModel(men, items);

            return View(viewMenu);
        }

        public IActionResult AddItem(int id)
        {
            Menu men = context.Menus.Single(c => c.ID == id);
            AddMenuItemViewModel addItem = new AddMenuItemViewModel(men, context.Cheeses.ToList());

            return View(addItem);

        }

        [HttpPost]
        public IActionResult AddItem(AddMenuItemViewModel vm)
        {
            if (ModelState.IsValid)
            {
                IList<CheeseMenu> existingItems = context.CheeseMenus
                               .Where(cm => cm.CheeseID == vm.CheeseID)
                               .Where(cm => cm.MenuID == vm.MenuID).ToList();

                if(existingItems.Count() == 0)
                {
                    CheeseMenu cMenu = new CheeseMenu
                    {
                        MenuID = vm.MenuID,
                        CheeseID = vm.CheeseID
                    };
                    context.CheeseMenus.Add(cMenu);
                    context.SaveChanges();
                    return Redirect("/Menu/ViewMenu/" + vm.MenuID);
                }

               
            }

            return View(vm);
        }
    }
}
