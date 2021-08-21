using AuctionAspNetMVCProject.Data.Interfaces;
using AuctionAspNetMVCProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionAspNetMVCProject.Controllers
{
    public class BidController : Controller
    {
        private readonly IAuctionRepository _auctionRepository;
        private readonly IUserRepository _userRepository;

        public BidController(IAuctionRepository auctionRepository, IUserRepository userRepository)
        {
            _auctionRepository = auctionRepository;
            _userRepository = userRepository;
        }
        public IActionResult Consult(Guid id)
        {
            {
                try
                {
                    //Search auction in data base using ID for it.
                    TempData["Consult"] = _auctionRepository.GetAuctionById(id);

                }
                catch (Exception e)
                {

                    TempData["Messege"] = e.Message;
                }
                return View();
            }
        }
    }
}
