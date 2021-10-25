using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Baby_Tracker.Models
{
    public class Sleep
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid SleepId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid BabyId { get; set; }

        
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{YYYY-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }
        
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{YYYY-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }

        [Display(Name = "Sleep Summary")]
        public Summary SleepSummary { get; set; }
        [Display(Name = "Nap?")]
        public bool IsNap { get; set; }
        [Display(Name = "Sleep interventions")]
        public ICollection<Intervention> Interventions { get; set; }
        [Display(Name = "Feeds during night time sleep.")]
        public ICollection<Feed> SleepFeeds { get; set; }

    }
}
