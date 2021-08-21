using AuctionAspNetMVCProject.Data.Entities;
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
        [HttpPost]
        public IActionResult Register(BidRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //getting user email
                    var email = User.Identity.Name;

                    //getting user data
                    var user = _userRepository.Get(email);
                    //creating Auction
                    var auction = new Auction();
                    
                }
                catch (Exception e)
                {
                     TempData["Message"] = "Erro: " + e.Message;
                }

            }
            return View();
        }
    }
                        
}
