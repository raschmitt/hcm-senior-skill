using System;
using System.Collections.Generic;

namespace Hcm.Skill.Domain.Models
{
    public class ClockingEvent
    {
        public List<Result> Result { get; set; }
    }

    public class Result
    {
        public DateTime CreatedAt { get; set; }
    }
}
