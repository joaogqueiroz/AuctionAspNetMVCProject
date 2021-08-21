using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionAspNetMVCProject.Models
{
    public class AuctionRegisterModel
    {
        public string Name { get; set; }


        public string StartDate { get; set; }


        public string StartHour { get; set; }


        public string FinishDate { get; set; }


        public string FinishHour { get; set; }


        public string Description { get; set; }


        public int Value { get; set; }
    }
}
