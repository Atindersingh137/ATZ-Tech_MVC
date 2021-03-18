using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ATZ_Tech_MVC.Models
{
    public class Product
    {
        public int ID { get; set; }   // primery key of product table 
        
        [Required]
        public string Name { get; set; } // name of product 
        public string Image { get; set; } // image 
        public int Price { get; set; } // price of product 
        public string Description { get; set; }  // product description 

    }
}
