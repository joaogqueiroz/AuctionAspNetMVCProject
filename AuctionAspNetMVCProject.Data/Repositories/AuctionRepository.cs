using AuctionAspNetMVCProject.Data.Entities;
using AuctionAspNetMVCProject.Data.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            var query = @"
                INSERT INTO AUCTION_TB(
                    AUCTIONID,
                    NAME,
	                STARTDATE,
	                STARTHOUR,
                    FINISHDATE,
	                FINISHHOUR,
	                DESCRIPTION,
                    VALUE,
	                USERID)
                VALUES(
                    NEWID(),
                    @Name,
                    @StartDate,
                    @StartHour,
                    @FinishDate,
                    @FinishHour,
                    @Description,
                    @Value,
                    @UserID)";
            using (var connetionString = new SqlConnection(_connectionString))
            {
                connetionString.Execute(query, auction);
            }
        }

        public void Update(Auction auction)
        {
            var query = @" 
                UPDATE AUCTION_TB SET
                    NAME = @Name,
                    STARTDATE = @StartDate,
                    STARTHOUR = @StartHour,
                    FINISHDATE = @FinishDate,
                    FINISHHOUR = @FinishHour,
                    DESCRIPTION = @Description,
                    VALUE = @Value
                WHERE
                    AUCTIONID = @AuctionID";
            using (var connetionString = new SqlConnection(_connectionString))
            {
                connetionString.Execute(query, auction);
            }

        }

        public void Delete(Auction auction)
        {
            var query = @"
                        DELETE FROM AUCTION_TB
                        WHERE AUCTIONID = @AuctionID";
            using (var connetionString = new SqlConnection(_connectionString))
            {
                connetionString.Execute(query, auction);
            }
        }

        public List<Auction> GetByUser(Guid userid)
        {
            var query = @"
                        SELECT * FROM AUCTION_TB
                        WHERE USERID = @userid
                        ORDER BY VALUE DESC";
            using (var connetionString = new SqlConnection(_connectionString))
            {
                return connetionString.Query<Auction>(query, new { userid }).ToList();
            }
        }

        public Task GetAuctionById(Guid auctionid)
        {
            var query = @"
                        SELECT * FROM AUCTION_TB
                        WHERE USERID = @userid";
            using (var connetionString = new SqlConnection(_connectionString))
            {
                return connetionString.Query<Task>(query, new { auctionid }).FirstOrDefault();
            }
        }

        public List<Auction> Read()
        {
            var query = @"
                        SELECT * FROM AUCTION_TB";
            using (var connetionString = new SqlConnection(_connectionString))
            {
                return connetionString.Query<Auction>(query).ToList();
            }
        }
    }
}
