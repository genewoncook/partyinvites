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

        [HttpGet]
        public ActionResult UploadFile()
        {
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

        /// <summary>
        /// Post method for uploading files
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            try
            {
                /*Geting the file name*/
                string filename = System.IO.Path.GetFileName(file.FileName);
                /*Saving the file in server folder*/
                file.SaveAs(Server.MapPath("~/Images/" + filename));
                string filepathtosave = "Images/" + filename;
                /*
                 * HERE WILL BE YOUR CODE TO SAVE THE FILE DETAIL IN DATA BASE
                 *
                 */

                ViewBag.Message = "File Uploaded successfully.";
            }
            catch
            {
                ViewBag.Message = "Error while uploading the files.";
            }
            return View();
        }
    }
}