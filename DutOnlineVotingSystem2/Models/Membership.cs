using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DutOnlineVotingSystem2.Models
{
    public class Membership
    {
        [Key]
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [Display(Name ="Date of Birth")]
        public DateTime? Birthdate { get; set; }

        [Required]
        public string StudentNumber { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [Phone]
        [Display(Name ="Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name ="Email Address")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Campus { get; set; }

        [Required]
        public string Party { get; set; }
    }
}