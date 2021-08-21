using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionAspNetMVCProject.Models
{
    public class AccountRegisterModel
    {
        [MaxLength(150, ErrorMessage = "Type a maximum of {1} characters")]
        [MinLength(6, ErrorMessage = "Type a minimum of {1} characters")]
        [Required(ErrorMessage = "Inform your name.")]
        public string Name { get; set; }

        [StartAge(19, ErrorMessage = "You need to be more than 18 years old")]
        [Required(ErrorMessage = "Confirm your birth date")]
        public DateTime BirthDate { get; set; }

        [EmailAddress(ErrorMessage = "Inform a valid email.")]
        [Required(ErrorMessage = "Inform your email.")]
        public string Email { get; set; }

        [StrongPassWord(ErrorMessage = "Inform a uppercase letter 1, 1 lowercase letter, 1 number and 1 special character(! @ # $ % & ).")]
        [MaxLength(20, ErrorMessage = "Type a maximum of {1} characters")]
        [MinLength(8, ErrorMessage = "Type a minimum of {1} characters")]
        [Required(ErrorMessage = "Inform your password.")]
        public string PassWord { get; set; }
        [Compare("PassWord", ErrorMessage = "The passwords don't are equals")]
        [Required(ErrorMessage = "Confirm your password")]
        public string PassWordConfirm { get; set; }


    }
    public class StrongPassWord : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                var password = value.ToString();

                return password.Any(char.IsUpper)
                    && password.Any(char.IsLower)
                    && password.Any(char.IsDigit)
                    && (password.Contains("!")
                       || password.Contains("@")
                       || password.Contains("#")
                       || password.Contains("$")
                       || password.Contains("%")
                       || password.Contains("&"));
            };
            return false;

        }


    }
    public class StartAge : ValidationAttribute
    {
        int _startAge;

        public StartAge(int startAge)
        {
            _startAge = startAge;
        }

        public override bool IsValid(object value)
        {
            DateTime date;
            try
            {
                if (DateTime.TryParse(value.ToString(), out date))
                    return date.AddYears(_startAge) < DateTime.Now;
            }
            catch (Exception) { }

            return false;
        }
    }
}
