using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Baby_Tracker.Models
{ 
    // A place to store all of our enums
    public enum LatchQuality
    {
        Efficient,
        Lazy,
        Average
    }

    public enum ChinEngagement
    {
        Engaged,
        Disengaged
    }

    public enum Alertness
    {
        High,
        Medium,
        Low,
        Asleep
    }

    public enum Fussiness
    {
        Calm,
        Irritated,
        Angry,
        Furious
    }

    public enum Summary
    {
        Good,
        OK,
        Poor,
        Terrible
    }

    public enum Sooth
    {
        Soother,
        CradleRocking,
        Pickup,
        Rocking,
        Shushing,
        Singing,
        WhiteNoise,
        Burping,
        OverKnee
    }
}
