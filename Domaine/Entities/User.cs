using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GP.Domain.Entities
{
    public class User

    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateofBirth { get; set; }
        public string City { get; set; }
        public string adress { get; set; }
        public int Zipcode { get; set; }
        public string gender { get; set; }
        [Required]
        public long Tele { get; set; }
        [Required, EmailAddress]
        public string mail { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string password { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string Confirmpassword { get; set; }
       // public enum Role { Admin, swapper }
    }
}
