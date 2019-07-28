using System;
using System.Collections.Generic;
using System.Linq;
using Centric.Internship.Mvc.Entities;
using Centric.Internship.Mvc.Models;
using Centric.Internship.Mvc.Storage;
using Microsoft.AspNetCore.Mvc;

namespace Centric.Internship.Mvc.Controllers
{

    [Route("event/")]
    public class EventController : Controller
    {
        [Route("index")]
        //[Authorize(Roles = "admin")]
        public ActionResult<IEnumerable<EventModel>> Index()
        {
            ViewData["NextEventName"] = EventStorage.Events.OrderBy(e => e.Date).ElementAt(0).Name;
            var events = EventStorage.Events.Select(eventEntity => new EventModel
            {
                Name = eventEntity.Name,
                Location = eventEntity.Location,
                Description = eventEntity.Description,
                Date = eventEntity.Date,
                Id = eventEntity.Id
            });
            return View(events.ToList());
        }

        [HttpGet("details/{id}")]
        ////[CustomActionFilter]
        public IActionResult Details([FromRoute]Guid id)
        {
            var eventEntity = EventStorage.Events.FirstOrDefault(e => e.Id.Equals(id));
            return View(new EventModel
            {
                Name = eventEntity.Name,
                Location = eventEntity.Location,
                Description = eventEntity.Description,
                ContactEmail = eventEntity.ContactEmail,
                Date = eventEntity.Date
            });
        }

        [HttpGet("create")]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost("create")]
        public ActionResult Create([FromForm] EventModel fromBody)
        {
            if (ModelState.IsValid)
            {
                EventStorage.AddEvent(new Event
                {
                    Id = Guid.NewGuid(),
                    Name = fromBody.Name,
                    Location = fromBody.Location,
                    Description = fromBody.Description,
                    ContactEmail = fromBody.ContactEmail,
                    Date = Convert.ToDateTime(fromBody.Date)
                });
            }
            else
            {
                return View("Create", fromBody);
            }
            
            return RedirectToAction("Index");
        }
    }
}