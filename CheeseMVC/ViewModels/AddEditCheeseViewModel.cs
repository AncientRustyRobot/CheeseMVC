using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheeseMVC.Models;

namespace CheeseMVC.ViewModels
{
    public class AddEditCheeseViewModel : AddCheeseViewModel
    {
        public int ID { get; set; }
        


        public AddEditCheeseViewModel()
        {
            
           
        }

        public AddEditCheeseViewModel(Cheese ch, IEnumerable<CheeseCategory> categories): 
            base(categories)
        {
            ID = ch.ID;
            Name = ch.Name;
            Description = ch.Description;
            CategoryID = ch.CategoryID;
            Rating = ch.Rating;


        }
    }

   

}
