using AuctionAspNetMVCProject.Data.Entities;
using AuctionAspNetMVCProject.Data.Interfaces;
using AuctionAspNetMVCProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AuctionAspNetMVCProject.Controllers
{
    public class AuctionController : Controller
    {
        private readonly IAuctionRepository _auctionRepository;
        private readonly IUserRepository _userRepository;

        public AuctionController(IAuctionRepository auctionRepository, IUserRepository userRepository)
        {
            _auctionRepository = auctionRepository;
            _userRepository = userRepository;
        }

        [Authorize]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(AuctionRegisterModel model)
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
                    auction.Name = model.Name;
                    auction.StartDate = DateTime.Parse(model.StartDate);
                    auction.StartHour = TimeSpan.Parse(model.StartHour);
                    auction.FinishDate = DateTime.Parse(model.FinishDate);
                    auction.FinishHour = TimeSpan.Parse(model.FinishHour);
                    auction.Description = model.Description;
                    auction.Value = float.Parse(model.Value);
                    auction.UserID = user.UserID; //Foreign key

                    _auctionRepository.Create(auction);
                    TempData["Message"] = $"auction created {auction.Name} successfully";
                    ModelState.Clear();
                }
                catch (Exception e)
                {

                    TempData["Message"] = "Erro: " + e.Message;
                }
            }
            return View();
        }
        public IActionResult Bid(Guid id)
        {
            {
                var model = new AuctionBidModel();
                try
                {
                    //Search auction in data base using ID for it.
                    TempData["Consult"] = _auctionRepository.GetAuctionById(id);

                }
                catch (Exception e)
                {

                    TempData["Messege"] = e.Message;
                }
                return View(model);
            }
        }
    }
}
