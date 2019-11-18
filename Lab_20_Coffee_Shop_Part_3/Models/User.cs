using System;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace Lab_20_Coffee_Shop_Part_3.Models
{
    public class User
    {
        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"(?=.*[!@#$%^&*])(?=.*\d)(?=.*[A-Z]).{8,}", ErrorMessage = "The password must contain a symbol(!@#$%^&*), a number, a capital letter, and must be atleast 8 characters.")]
        public string Pass { get; set; }
        [Required]
        public string Regular { get; set; }
        [Required]
        public string Member { get; set; }
    }
}
