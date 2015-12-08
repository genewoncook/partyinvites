using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//My includes
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewData["greeting"] = (hour < 12 ? "Good morning" : "Good afternoon");
            return View();
        }

        [HttpGet]
        public ActionResult RsvpForm()
        {
            //return new EmptyResult();
            return View();
        }

        [HttpPost]
        public ActionResult RsvpForm(GuestResponse guestResponse)
        {
            //TODO: Email
            if (ModelState.IsValid)
                return View("Thanks", guestResponse);
            else // There's a validation error so redisplay the form
                return View();
        }
    }
}