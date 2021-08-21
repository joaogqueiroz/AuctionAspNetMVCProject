using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionAspNetMVCProject.Models
{
    public class BidRegisterModel
    {
        public Guid AuctionID { get; set; }
        [MaxLength(150, ErrorMessage = "Type a maximum of {1} characters")]
        [MinLength(6, ErrorMessage = "Type a minimum of {1} characters")]
        [Required(ErrorMessage = "Inform auction name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Inform the auction start date.")]
        public string StartDate { get; set; }

        [Required(ErrorMessage = "Inform the auction start hour.")]
        public string StartHour { get; set; }

        [Required(ErrorMessage = "Inform the auction finish date.")]
        public string FinishDate { get; set; }


        [Required(ErrorMessage = "Inform the auction finish hour.")]
        public string FinishHour { get; set; }

        [MaxLength(150, ErrorMessage = "Description should have {1} maximum characters.")]
        [Required(ErrorMessage = "Inform auction description.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Inform auction value.")]
        public string Value { get; set; }
    }
}
