﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Baby_Tracker.Models
{ 
    // A place to store all of our enums
    public enum LatchQuality
    {
        None,
        Efficient,
        Lazy,
        Average
    }

    public enum ChinEngagement
    {
        None,
        Engaged,
        Disengaged
    }

    public enum Alertness
    {
        None,
        High,
        Medium,
        Low,
        Asleep
    }

    public enum Fussiness
    {
        None,
        Calm,
        Irritated,
        Angry,
        Furious
    }

    public enum Summary
    {
        None,
        Good,
        OK,
        Poor,
        Terrible
    }

    public enum Sooth
    {
        None,
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
