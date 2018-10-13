using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FAADroneRegistrationApplication.Models
{
    public class Users
    {
        public int ID { get; set; }

        [StringLength(20, MinimumLength = 2)]
        [Required]
        public String FirstName { get; set; }

        [StringLength(20, MinimumLength = 2)]
        [Required]
        public String LastName { get; set; }

        [StringLength(80, MinimumLength = 2)]
        [Required]
        public String Address { get; set; }
        /*
        public String ZipCode { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        */
        
        [Required]
        public int DroneIdNumber { get; set; }

       // public int FAANumberID {get; set; }

        /*
        public void generateFAANumberID()
        {
            // Extremely crude. Needs validation for repeating ID numbers (checking users database). ONLY FOR PROTOTYPING //
            Random rnd = new Random();
            int value = rnd.Next(100000, 999999);
            this.DroneIdNumber = value;
        }
        */
    }
}
