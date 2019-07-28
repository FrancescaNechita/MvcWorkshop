using Centric.Internship.Mvc.Custom;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Centric.Internship.Mvc.Models
{
    public class EventModel
    {
        private DateTime _createdOn = DateTime.MinValue;

        [BindProperty] public Guid Id { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(1000)]
        [MinLength(10)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        [StringLength(1000)]
        [MinLength(10)]
        public string Location { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(1000)]
        [MinLength(10)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailSpecification]
        [EmailAddress(ErrorMessage = "Email address does not have a correct format.")]
        public string ContactEmail { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date
        {
            get { return (_createdOn == DateTime.MinValue) ? DateTime.Now : _createdOn; }

            set { _createdOn = value; }
        }
    }
}
