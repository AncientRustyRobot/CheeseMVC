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

        [Required]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        public List<SelectListItem> Categories { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        public AddCheeseViewModel()
        {

        }

        public AddCheeseViewModel(IEnumerable<CheeseCategory> categories)
        {
            
            Categories = new List<SelectListItem>();

            foreach(CheeseCategory category in categories)
            {
                Categories.Add(new SelectListItem {
                    Value = (category.ID.ToString()),
                    Text = (category.Name)
                });
                        

            }

        }

        public Cheese CreateCheese()
        {
            Cheese newCheese = new Cheese
            {
                Name = this.Name,
                Description = this.Description,
                CategoryID = this.CategoryID,
                Rating = this.Rating

            };
            return newCheese;



        }
       

    }
}
