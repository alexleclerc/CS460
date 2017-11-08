using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Homework5.Models
{
    public class Address
    {
        [Display(Name = "ID Number:"), Required]
        public int ID { get; set; }

        [Display(Name = "Date of Birth:"), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy"), Required]
        public DateTime DOB { get; set; }

        [Display(Name = "Last Name:"), Required]
        public string LastName { get; set; }

        [Display(Name = "First Name:"), Required]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name:")]
        public string MiddleName { get; set; }

        [Display(Name = "Address:"), Required]
        public string Addr { get; set; }

        [Display(Name = "City:"), Required]
        public string City { get; set; }

        [Display(Name = "State:"), Required]
        public string State { get; set; }

        [Display(Name = "Zip Code:"), Required]
        public string ZipCode { get; set; }

        [Display(Name = "County:"), Required]
        public string County { get; set; }
    }

}