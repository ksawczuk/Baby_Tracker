using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Baby_Tracker.Models
{
    public class Sleep
    {
        [Required]
        public Guid SleepId { get; set; }
        [Required]
        public Guid BabyId { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<Intervention> Interventions { get; set; }
        public List<Feed> SleepFeeds { get; set; }
        public Summary SleepSummary { get; set; }
        public bool IsNap { get; set; }

        public Sleep()
        {
            StartTime = DateTime.Now;
        }
    }

    public class Intervention
    {
        [Required]
        public Guid InterventionId { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Sooth FirstTry { get; set; }
        public Sooth SecondTry { get; set; }
        public Sooth ThirdTry { get; set; }
        public Sooth FourthTry { get; set; }
        public Summary InterventionSummary { get; set; }
    }
}
