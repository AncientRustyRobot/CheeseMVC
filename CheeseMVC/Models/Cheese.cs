using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models
{
    public class Cheese
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Cheese(string name, string descritpion)
        {
            this.Name = name;
            this.Description = descritpion;
        }
        

    }
}
