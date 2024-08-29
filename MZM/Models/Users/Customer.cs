using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MZM.Models.Users
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string CustomerID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Name")]
        public string FirstName { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Surname")]
        public string LastName { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter Phone Number")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string ContactNo { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Password and confirm password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Status { get; set; }

        public string Feedback { get; set; }
        //public double Amount { get; set; } = 0.0;

        public string Contacts { get; set; }

        public string textarea { get; set; }
        //[Display(Name = "Active")]
        //public bool Status { get; set; }
        //[DataType(DataType.Upload)]
        //public byte[] Picture { get; set; }

        public string Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}