using System;
using System.Collections.Generic;

namespace dotNetAssignment.DataEntities
{
    public partial class Rules : BaseEntity
    {
        public Rules()
        {
            RateChart = new HashSet<RateChart>();
        }

        public int Id { get; set; }
        public string RuleText { get; set; }

        public virtual ICollection<RateChart> RateChart { get; set; }
    }
}
