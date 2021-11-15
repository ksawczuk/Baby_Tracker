using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Baby_Tracker.Models
{
    public class Intervention
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid InterventionId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public Guid SleepId { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Time")]
        [Required]
        public DateTime StartTime { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd HH:mm}", ApplyFormatInEditMode = true)]
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
