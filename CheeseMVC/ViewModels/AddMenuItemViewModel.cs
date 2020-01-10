using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CheeseMVC.ViewModels
{
    public class AddMenuItemViewModel
    {
        public int MenuID { get; set; }
        public int CheeseID { get; set; }
        public Menu Menu { get; set; }
        public List<SelectListItem> Cheeses { get; set; }

        public AddMenuItemViewModel()
        {

        }

        public AddMenuItemViewModel(Menu men, IEnumerable<Cheese> cheeses)
        {
            Menu = men;

            Cheeses = new List<SelectListItem>();

            foreach (Cheese cheese in cheeses)
            {
                Cheeses.Add(new SelectListItem
                {
                    Value = (cheese.ID.ToString()),
                    Text = (cheese.Name)
                });



            }

        }

    }
}
