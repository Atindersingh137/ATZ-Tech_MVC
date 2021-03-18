using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ATZ_Tech_MVC.Models
{
    public class Order
    {
        public int ID { get; set; }
        [Required]
        public int UserID { get; set; }
        public User User { get; set; }    // link user class with order 


        // [ForeignKey("Product")]
        public int ProductID { get; set; }   // product is as a forign key from product table 
        public Product Product { get; set; } // link product class  with products
    }
}
