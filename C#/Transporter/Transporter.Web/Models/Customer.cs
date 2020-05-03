using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Transporter.Web.Models
{
    // Form model
    public class Customer
    {
        [Display(Name = "Customer ID")]
        [Required]
        public int Id { get; set; }

        [Display(Name = "Customer Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Customer Adress")]
        [Required]
        public string Adress { get; set; }

        [Display(Name = "Customer Phone Number")]
        [Required]
        [StringLength(12, MinimumLength = 11)]
        public string PhoneNum { get; set; }

        [Display(Name = "Customer E-Mail Adress")]
        [Required]
        public string EMail { get; set; }
    }
}