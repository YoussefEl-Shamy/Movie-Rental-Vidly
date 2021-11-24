using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.DTOs
{
    public class CustomerDto
    {
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }

        public bool isSubscribedToNewsletter { get; set; }

        [Required]
        public byte membershipTypeId { get; set; }

        public MembershipTypeDto membershipType { get; set; }

        //[Min18YearsIfAMember]
        public DateTime? birthdate { get; set; }
    }
}