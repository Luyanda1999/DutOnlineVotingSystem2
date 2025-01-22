using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DutOnlineVotingSystem2.Models
{
    public class Candidates
    {
        [Key]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType GetMembershipType { get; set; }

        [Required]
        [Display(Name ="Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Required]
        [Display(Name ="Party Name")]
        public string partyName { get; set; }
    }

    public class MembershipType
    {
    }
}