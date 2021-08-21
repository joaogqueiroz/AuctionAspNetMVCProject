using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionAspNetMVCProject.Data.Entities
{
    public class Auction
    {
        public Guid AuctionID { get; set; }
        public string Name { get; set; }

        public DateTime StartDate { get; set; }
        public TimeSpan StartHour { get; set; }
        public DateTime FinishDate { get; set; }
        public TimeSpan FinishHour { get; set; }
        public string Description { get; set; }
        public float Value { get; set; }
        public Guid UserID { get; set; }

        //Have one
        public User User { get; set; }
    }
}
