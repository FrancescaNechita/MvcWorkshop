using System.Linq;
using Centric.Internship.Mvc.Models;
using Centric.Internship.Mvc.Storage;
using Microsoft.AspNetCore.Mvc;

namespace Centric.Internship.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var eventEntity = EventStorage.Events.ElementAt(0);
            return View(new EventModel
            {
                Name = eventEntity.Name,
                Location = eventEntity.Location,
                Date = eventEntity.Date
            });
        }
    }
}