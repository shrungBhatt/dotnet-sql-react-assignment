using System;
using System.Collections.Generic;

namespace dotNetAssignment.DataEntities
{
    public partial class CoveragePlan : BaseEntity
    {
        public CoveragePlan()
        {
            Contracts = new HashSet<Contracts>();
            RateChart = new HashSet<RateChart>();
        }

        public int Id { get; set; }
        public string CoveragePlan1 { get; set; }
        public DateTime EligFromDate { get; set; }
        public DateTime EligToDate { get; set; }
        public int EligCountry { get; set; }

        public virtual Country EligCountryNavigation { get; set; }
        public virtual ICollection<Contracts> Contracts { get; set; }
        public virtual ICollection<RateChart> RateChart { get; set; }
    }
}
