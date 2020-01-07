using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace CheeseMVC.ViewModels
{
    public class AddCheeseViewModel
    {   
        [Required(ErrorMessage = "Please enter a cheese")]
        [Display(Name = "Cheese Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "You must give your cheese a description")]
        [Display(Name = "Cheese Description")]
        public string Description { get; set; }

        public CheeseType Type { get; set; }
        public List<SelectListItem> CheeseTypes { get; set; }
        
        [Range(1, 5)]
        public int Rating { get; set; }

        public AddCheeseViewModel()
        {
            CheeseTypes = new List<SelectListItem>();
            CheeseTypes.Add(new SelectListItem
            {
                Value = ((int) CheeseType.Fake).ToString(),
                Text =  CheeseType.Fake.ToString()
            });
            CheeseTypes.Add(new SelectListItem
            {
                Value = ((int)CheeseType.Hard).ToString(),
                Text = CheeseType.Hard.ToString()
            });
            CheeseTypes.Add(new SelectListItem
            {
                Value = ((int)CheeseType.Soft).ToString(),
                Text = CheeseType.Soft.ToString()
            });
        }

        public Cheese CreateCheese()
        {
            Cheese newCheese = new Cheese
            {
                Name = Name,
                Description = Description,
                Type = Type,
                Rating = Rating

            };
            return newCheese;



        }
       

    }
}
