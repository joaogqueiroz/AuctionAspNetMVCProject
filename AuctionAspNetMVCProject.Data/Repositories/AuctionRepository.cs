using AuctionAspNetMVCProject.Data.Entities;
using AuctionAspNetMVCProject.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionAspNetMVCProject.Data.Repositories
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly string _connectionString;

        public AuctionRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Create(Auction auction)
        {
            throw new NotImplementedException();
        }

        public void Update(Auction auction)
        {
            throw new NotImplementedException();
        }

        public void Delete(Auction auction)
        {
            throw new NotImplementedException();
        }

        public List<Auction> GetByUser(Guid userid)
        {
            throw new NotImplementedException();
        }

        public Task GetAuctionById(Guid taskid)
        {
            throw new NotImplementedException();
        }
    }
}
