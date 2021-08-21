using AuctionAspNetMVCProject.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionAspNetMVCProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuctionRepository _auctionRepository;

        public HomeController(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }

        [Authorize]
        public IActionResult Index()
        {
            try
            {
                TempData["Consult"] = _auctionRepository.Read();
            }
            catch (Exception e)
            {

                TempData["Messege"] = e.Message;
            }
            return View();
        }
    }
}
