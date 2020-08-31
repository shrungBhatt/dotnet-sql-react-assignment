using System;
using System.Collections.Generic;

namespace dotNetAssignment.DataEntities
{
    public partial class RateChart : BaseEntity
    {
        public RateChart()
        {
            Contracts = new HashSet<Contracts>();
        }

        public int Id { get; set; }
        public int CoveragePlan { get; set; }
        public int CustomerGender { get; set; }
        public int AppliedRule { get; set; }
        public int Age { get; set; }
        public decimal NetPrice { get; set; }

        public virtual Rules AppliedRuleNavigation { get; set; }
        public virtual CoveragePlan CoveragePlanNavigation { get; set; }
        public virtual Gender CustomerGenderNavigation { get; set; }
        public virtual ICollection<Contracts> Contracts { get; set; }
    }
}
