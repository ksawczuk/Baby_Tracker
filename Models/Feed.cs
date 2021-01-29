using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Baby_Tracker.Models
{
    public class Feed
    {
        public Guid FeedId { get; set; }
        public Guid BabyId { get; set; }
        public Guid? SleepId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public LatchQuality LatchQuality { get; set; }
        public ChinEngagement ChinEngagement { get; set; }
        public Alertness Alertness { get; set; }
        public Fussiness Fussiness { get; set; }
        public Summary FeedSummary { get; set; }
        public bool IsDreamFeed { get; set; }

        public Feed()
        {
            StartTime = DateTime.Now;
        }
    }
}
