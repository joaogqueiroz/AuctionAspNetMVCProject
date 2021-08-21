using AuctionAspNetMVCProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionAspNetMVCProject.Data.Interfaces
{
    public interface IAuctionRepository
    {
        void Create(Auction auction);
        void Update(Auction auction);
        void Delete(Auction auction);
        List<Auction> Read();
        List<Auction> GetByUser(Guid userid);
        Task GetAuctionById(Guid auctionid);
    }
}
