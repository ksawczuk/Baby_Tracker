using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Baby_Tracker.Models
{
    // This class might not be needed (comment as of 07/20/2021)
    public class BabyUser : IdentityUser
    {
        [PersonalData]
        public Guid OtherOwnerId1 { get; set; }
        [PersonalData]
        public Guid OtherOwnerId2 { get; set; }
    }
}
