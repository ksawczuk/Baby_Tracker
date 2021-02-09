using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Baby_Tracker.Models
{
    public class Sleep
    {
        public Guid SleepId { get; set; }
        public Guid BabyId { get; set; }
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }
        public List<Intervention> Interventions { get; set; }
        [Display (Name = "Sleep Feeds")]
        public List<Feed> SleepFeeds { get; set; }
        [Display(Name = "Sleep Summary")]
        public Summary SleepSummary { get; set; }
        [Display(Name = "Nap?")]
        public bool IsNap { get; set; }

    }

    public class Intervention
    {
        public Guid InterventionId { get; set; }
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }
        [Display(Name = "First Try")]
        public Sooth FirstTry { get; set; }
        [Display(Name = "Second Try")]
        public Sooth SecondTry { get; set; }
        [Display(Name = "Third Try")]
        public Sooth ThirdTry { get; set; }
        [Display(Name = "Fourth Try")]
        public Sooth FourthTry { get; set; }
        [Display(Name = "Intervention Summary")]
        public Summary InterventionSummary { get; set; }
    }
}
