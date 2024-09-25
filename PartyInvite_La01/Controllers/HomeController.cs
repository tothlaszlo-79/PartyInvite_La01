using Microsoft.AspNetCore.Mvc;
using PartyInvite_La01.Models;
using System.Diagnostics;

namespace PartyInvite_La01.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greetings = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View("MyView");
        }

        [HttpGet]
        public ViewResult InviteForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult InviteForm(GuestResponse response)
        {
            Repository.AddResponse(response);
            return View("Thanks", response);
        }

        public ViewResult ListResponses() { 
            return View(
            Repository.Responses.Where(r=>r.WillAttend == true)    
                );
        }
    }
}
