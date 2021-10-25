using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Baby_Tracker.Models
{

    // Standard class for Baby
    public class Baby
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid BabyId { get; set; }
        public string OwnerId1 { get; set; }
        public string OwnerId2 { get; set; }
        public string OwnerId3 { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string ImageFileName { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{YYYY-MM-dd}")]
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{YYYY-MM-dd HH:mm:ss}")]
        [Display(Name = "Birth Date & Time")]
        public DateTime BirthDateTime { get; set; }
        [Display(Name = "Birth Weight")]
        public double BirthWeight { get; set; }
        [Display(Name = "Birth Height")]
        public double BirthHeight { get; set; }
        public ICollection<Sleep> Sleeps { get; set; }
        public ICollection<Feed> Feeds { get; set; }

    }
}
