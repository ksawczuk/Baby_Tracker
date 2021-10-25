﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Baby_Tracker.Models
{
    public class Feed
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid FeedId { get; set; }
        public Guid BabyId { get; set; }
        public Guid? SleepId { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{YYYY-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{YYYY-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }
        [Display(Name = "Latch Quality")]
        public LatchQuality LatchQuality { get; set; }
        [Display(Name = "Chin Engagement")]
        public ChinEngagement ChinEngagement { get; set; }
        public Alertness Alertness { get; set; }
        public Fussiness Fussiness { get; set; }
        [Display(Name = "Feed Summary")]
        public Summary FeedSummary { get; set; }
        [Display(Name = "Dream Feed?")]
        public bool IsDreamFeed { get; set; }

    }
}
