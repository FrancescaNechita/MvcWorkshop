using System;
using System.Collections.Generic;
using Centric.Internship.Mvc.Entities;

namespace Centric.Internship.Mvc.Storage
{
    public class EventStorage
    {
        public static List<Event> Events = new List<Event>
        {
            new Event
            {
                Name = "Afterhills",
                Description = "Music festival",
                Location = "Dobrovat, Iasi",
                Date = new DateTime(2019, 8, 23),
                ContactEmail = "marinela.marchitan@centric.eu",
                Id = Guid.NewGuid()
            },
            new Event
            {
                Name = "Hackathon",
                Description = "For code lovers",
                Location = "Centric",
                Date = new DateTime(2019, 10, 03),
                ContactEmail = "marinela.marchitan@centric.eu",
                Id = Guid.NewGuid()
            },
            new Event
            {
                Name = "Marathon",
                Description = "Running competition",
                Location = "Iasi",
                Date = new DateTime(2019, 9, 11),
                ContactEmail = "marinela.marchitan@centric.eu",
                Id = Guid.NewGuid()
            }
        };
        public static void AddEvent(Event model)
        {
            Events.Add(model);
        }
    }
}