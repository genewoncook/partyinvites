using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PartyInvites.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Required Field")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "That is not a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required Field")]
        public string Phone { get; set; }

        [Required(ErrorMessage ="Are you planning on attending?")]
        public bool? WillAttend { get; set; }
    }
}