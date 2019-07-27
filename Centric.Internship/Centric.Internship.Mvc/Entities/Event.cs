using System;

namespace Centric.Internship.Mvc.Entities
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Website { get; set; }
        public string ContactEmail { get; set; }
        public DateTime Date { get; set; }
    }
}