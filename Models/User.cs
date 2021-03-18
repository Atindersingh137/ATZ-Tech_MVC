using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ATZ_Tech_MVC.Models
{
    public class User
    {
        
        public int ID { get; set; }  // primery key for user table 
        [Required]
        public string FirstName { get; set; } // user name 
        public string LastName { get; set; }
        public string Gender { get; set; }// gender
        public DateTime DOB { get; set; }// date of birth
        public string Address { get; set; } // address
        public int Mobile { get; set; }// mobile
       
    }
}
