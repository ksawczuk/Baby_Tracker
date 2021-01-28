using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.ComponentModel.DataAnnotations;

namespace Baby_Tracker.Models
{

    // Standard class for Baby
    public class Baby
    {
        [Required]
        public Guid BabyId { get; set; }
        [Required]
        public string OwnerId1 { get; set; }
        public string OwnerId2 { get; set; }
        public string OwnerId3 { get; set; }
        [Required]
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string ImageFileName { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        public double Height { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        public DateTime BirthDateTime { get; set; }
        [Required]
        public double BirthWeight { get; set; }
        [Required]
        public double BirthHeight { get; set; }
        public List<Sleep> Sleeps { get; set; }
        public List<Feed> Feeds { get; set; }

        // Default DateAdded to current date and time.

        public Baby()
        {
            DateAdded = DateTime.Now;
        }
    }
}
