using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Please Enter Customer's Name")]
        [StringLength(255)]
        [Display(Name = "Full Name")]
        public string name { get; set; }
        
        public bool isSubscribedToNewsletter { get; set; }

        public MembershipType membershipType { get; set; }

        [Required(ErrorMessage = "Please Select Customer's Membership Type")]
        [Display(Name = "Membership Type")]
        public byte membershipTypeId { get; set; }

        [Display(Name = "Date Of Birth")]
        [Min18YearsIfAMember]
        public DateTime? birthdate { get; set; }
    }
}