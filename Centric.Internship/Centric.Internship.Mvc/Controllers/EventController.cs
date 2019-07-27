using System.Linq;
using Centric.Internship.Mvc.Models;
using Centric.Internship.Mvc.Storage;
using Microsoft.AspNetCore.Mvc;

namespace Centric.Internship.Mvc.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            ViewData["NextEventName"] = EventStorage.Events.OrderBy(e => e.Date).ElementAt(0).Name;
            return View();
        }

        public IActionResult Details()
        {
            var eventEntity = EventStorage.Events.OrderBy(e => e.Date).ElementAt(0);
            return View(new EventModel
            {
                Name = eventEntity.Name,
                Location = eventEntity.Location,
                Date = eventEntity.Date
            });
        }
    }
}